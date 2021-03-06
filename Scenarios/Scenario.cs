﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Curvature
{
    [DataContract(Namespace = "")]
    public class Scenario : INameable, IInputBroker
    {
        public interface IScenarioMember
        {
            string GetName();
            PointF GetPosition();
            double GetProperty(string name);
            float GetRadius();
        }

        public class Score
        {
            public double InputValue;
            public double FinalScore;
        }

        public class ConsiderationScores
        {
            public Dictionary<Consideration, Score> Considerations;
            public double InitialWeight;
            public double FinalScore;

            public override string ToString()
            {
                string ret = $"Initial weight: {InitialWeight}\r\nFinal score: {FinalScore}\r\n\r\n";
                foreach (var pair in Considerations)
                {
                    ret += $"{pair.Key.ReadableName}\r\nInput \"{pair.Key.Input.ReadableName}\" = {pair.Value.InputValue}, score = {pair.Value.FinalScore}\r\n\r\n";
                }

                return ret;
            }
        }

        public class Context
        {
            public ScenarioAgent ThinkingAgent;
            public IScenarioMember Target;
            public Behavior ChosenBehavior;
            public ConsiderationScores BehaviorScore;

            public override string ToString()
            {
                return $"Target: {Target.GetName()}\r\nBehavior: {ChosenBehavior} [{ChosenBehavior.Action}]\r\n{BehaviorScore}";
            }
        }

        [DataMember]
        public string ReadableName;

        [DataMember]
        public List<ScenarioAgent> Agents;

        [DataMember]
        public List<ScenarioLocation> Locations;

        private Pen RenderPenDottedBlack;
        private float HorizontalUnitsVisible = 2.0f;
        private float VerticalUnitsVisible = 2.0f;

        private float HorizontalUnitsOffset = 0.5f;
        private float VerticalUnitsOffset = 0.5f;

        private Random RandomNumbers = new Random();

        private HashSet<ScenarioAgent> AgentsActiveThisTick;
        private Dictionary<ScenarioAgent, DecisionHistory> AgentDecisions;
        private List<Context> CustomActions;


        public class DecisionHistory
        {
            public List<Context> ScoredContexts;
            public Context WinningContext;
        }

        internal class ScenarioEventArgs : EventArgs
        {
            internal float DeltaTime;
            internal Dictionary<ScenarioAgent, DecisionHistory> AgentDecisions;
        }

        internal delegate void ScenarioEventHandler(object sender, ScenarioEventArgs args);
        internal event ScenarioEventHandler SimulationAdvance;

        internal delegate void DialogRebuildNeededHandler();
        internal event DialogRebuildNeededHandler DialogRebuildNeeded;


        public Scenario(string name)
        {
            ReadableName = name;

            Agents = new List<ScenarioAgent>();
            Locations = new List<ScenarioLocation>();

            InitializeDrawingResources();
        }

        public void Advance(float dt)
        {
            AgentDecisions = new Dictionary<ScenarioAgent, DecisionHistory>();
            AgentsActiveThisTick = new HashSet<ScenarioAgent>();
            CustomActions = null;

            List<IScenarioMember> targets = new List<IScenarioMember>();
            targets.AddRange(Agents);
            targets.AddRange(Locations);

            foreach (var agent in Agents)
            {
                var decisionhistory = new DecisionHistory();
                decisionhistory.ScoredContexts = new List<Context>();

                var context = agent.ChooseBehavior(this, targets, decisionhistory);
                if (context != null)
                    ExecuteBehaviorOnAgent(context, dt);
                else
                    SignalStallOnAgent(agent);

                decisionhistory.WinningContext = context;
                AgentDecisions.Add(agent, decisionhistory);
            }

            SimulationAdvance(this, new ScenarioEventArgs { DeltaTime = dt, AgentDecisions = AgentDecisions });
        }


        public void Render(Graphics graphics, Rectangle rect)
        {
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;


            // Set up scaling
            PointF minCoordinate;
            PointF maxCoordinate;

            if (Agents.Count > 0)
            {
                minCoordinate = new PointF(1e6f, 1e6f);
                maxCoordinate = new PointF(-1e6f, -1e6f);

                foreach (var agent in Agents)
                {
                    var minpos = agent.GetPosition();
                    minpos.X -= (agent.Radius * 2.5f);
                    minpos.Y -= (agent.Radius * 2.5f);

                    var maxpos = agent.GetPosition();
                    maxpos.X += (agent.Radius * 2.5f);
                    maxpos.Y += (agent.Radius * 2.5f);

                    minCoordinate.X = Math.Min(minCoordinate.X, minpos.X);
                    minCoordinate.Y = Math.Min(minCoordinate.Y, minpos.Y);

                    maxCoordinate.X = Math.Max(maxCoordinate.X, maxpos.X);
                    maxCoordinate.Y = Math.Max(maxCoordinate.Y, maxpos.Y);
                }

                foreach (var loc in Locations)
                {
                    var minpos = loc.GetPosition();
                    minpos.X -= (loc.Radius * 1.5f);
                    minpos.Y -= (loc.Radius * 1.5f);

                    var maxpos = loc.GetPosition();
                    maxpos.X += (loc.Radius * 1.5f);
                    maxpos.Y += (loc.Radius * 1.5f);

                    minCoordinate.X = Math.Min(minCoordinate.X, minpos.X);
                    minCoordinate.Y = Math.Min(minCoordinate.Y, minpos.Y);

                    maxCoordinate.X = Math.Max(maxCoordinate.X, maxpos.X);
                    maxCoordinate.Y = Math.Max(maxCoordinate.Y, maxpos.Y);
                }
            }
            else
            {
                 minCoordinate = new PointF(1.0f, 1.0f);
                 maxCoordinate = new PointF(-1.0f, -1.0f);
            }

            HorizontalUnitsVisible = Math.Max(2.0f, (maxCoordinate.X - minCoordinate.X));
            VerticalUnitsVisible = Math.Max(2.0f, (maxCoordinate.Y - minCoordinate.Y));

            HorizontalUnitsOffset = -minCoordinate.X;
            VerticalUnitsOffset = -minCoordinate.Y;

            // Backplot and axes
            graphics.FillRectangle(Brushes.White, rect);
            graphics.DrawLine(RenderPenDottedBlack, CoordinatesToDisplayPoint(minCoordinate.X, 0.0f, rect), CoordinatesToDisplayPoint(maxCoordinate.X, 0.0f, rect));
            graphics.DrawLine(RenderPenDottedBlack, CoordinatesToDisplayPoint(0.0f, minCoordinate.Y, rect), CoordinatesToDisplayPoint(0.0f, maxCoordinate.Y, rect));

            // Locations
            foreach (var loc in Locations)
            {
                var displayRect = ToDisplayRect(loc, rect);
                graphics.FillEllipse(Brushes.Gray, displayRect);

                int pad = 20;
                var textRect = new Rectangle(displayRect.Left - pad, displayRect.Top + displayRect.Height + 5, displayRect.Width + pad * 2, pad + 5);
                graphics.DrawString(loc.GetName(), SystemFonts.IconTitleFont, Brushes.DarkGreen, textRect, stringFormat);
            }

            // Agents
            foreach (var agent in Agents)
            {
                var displayRect = ToDisplayRect(agent, rect);

                var brush = Brushes.Black;
                if (AgentsActiveThisTick != null && AgentsActiveThisTick.Contains(agent))
                    brush = Brushes.DarkGreen;

                graphics.FillEllipse(brush, displayRect);

                if (agent.Stalled)
                    graphics.DrawRectangle(Pens.Red, displayRect);

                int pad = 20;
                var textRect = new Rectangle(displayRect.Left - pad, displayRect.Top - pad, displayRect.Width + pad * 2, displayRect.Height + pad * 2);
                graphics.DrawString(agent.GetName(), SystemFonts.IconTitleFont, Brushes.Red, textRect, stringFormat);
            }

            // Custom action balloons
            if (CustomActions != null)
            {
                foreach (var ctx in CustomActions)
                {
                    if (ctx.Target != null)
                    {
                        var targetCenter = CoordinatesToDisplayPoint(ctx.Target.GetPosition().X, ctx.Target.GetPosition().Y, rect);
                        var agentCenter = CoordinatesToDisplayPoint(ctx.ThinkingAgent.GetPosition().X, ctx.ThinkingAgent.GetPosition().Y, rect);
                        graphics.DrawLine(Pens.Blue, targetCenter, agentCenter);

                        var midpoint = new Point((agentCenter.X + targetCenter.X) / 2, (agentCenter.Y + targetCenter.Y) / 2);
                        var textRect = new Rectangle(midpoint.X - 60, midpoint.Y - 15, 120, 30);
                        graphics.DrawString(ctx.ChosenBehavior.Payload, SystemFonts.IconTitleFont, Brushes.Blue, textRect, stringFormat);
                    }
                    else
                    {
                        int pad = 20;
                        var displayRect = ToDisplayRect(ctx.ThinkingAgent, rect);
                        var textRect = new Rectangle(displayRect.Left - pad, displayRect.Top - pad, displayRect.Width + pad * 2, pad * 3);
                        graphics.DrawString(ctx.ChosenBehavior.Payload, SystemFonts.IconTitleFont, Brushes.Blue, textRect, stringFormat);
                    }
                }
            }
        }

        public void Rename(string newname)
        {
            ReadableName = newname;
            DialogRebuildNeeded?.Invoke();
        }

        public string GetName()
        {
            return ReadableName;
        }

        public void RefreshInputs()
        {
        }

        public double GetInputValue(InputAxis axis)
        {
            return 0.0;
        }

        public double GetInputValue(InputAxis axis, Context context)
        {
            double raw = 0.0;

            switch (axis.Origin)
            {
                case InputAxis.OriginType.ComputedValue:
                    // TODO - compute stuff that isn't distance
                    raw = Distance(context.ThinkingAgent.GetPosition(), context.Target.GetPosition());
                    break;

                case InputAxis.OriginType.PropertyOfSelf:
                    raw = context.ThinkingAgent.GetProperty(axis.KBRec.ReadableName);
                    break;

                case InputAxis.OriginType.PropertyOfTarget:
                    raw = context.Target.GetProperty(axis.KBRec.ReadableName);
                    break;
            }

            return raw;
        }


        private void ExecuteBehaviorOnAgent(Context context, float dt)
        {
            const float speed = 1.0f;

            context.ThinkingAgent.Stalled = false;

            switch (context.ChosenBehavior.Action)
            {
                case Behavior.ActionType.Idle:
                    break;

                case Behavior.ActionType.MoveAwayFromTarget:
                    if (context.Target != null)
                    {
                        var pos = context.ThinkingAgent.Position;
                        var vec = ComputeVectorTowardsTarget(context);
                        context.ThinkingAgent.Position.X = ClampToEscape(pos.X, context.Target.GetPosition().X, pos.X - (speed * dt * vec.X));
                        context.ThinkingAgent.Position.Y = ClampToEscape(pos.Y, context.Target.GetPosition().Y, pos.Y - (speed * dt * vec.Y));
                    }
                    break;

                case Behavior.ActionType.MoveToTarget:
                    if (context.Target != null)
                    {
                        var pos = context.ThinkingAgent.Position;
                        var vec = ComputeVectorTowardsTarget(context);
                        context.ThinkingAgent.Position.X = ClampToArrival(pos.X, context.Target.GetPosition().X, pos.X + (speed * dt * vec.X));
                        context.ThinkingAgent.Position.Y = ClampToArrival(pos.Y, context.Target.GetPosition().Y, pos.Y + (speed * dt * vec.Y));
                    }
                    break;

                case Behavior.ActionType.Talk:
                    if (CustomActions == null)
                        CustomActions = new List<Context>();

                    CustomActions.Add(context);
                    break;

                case Behavior.ActionType.Custom:
                    if (CustomActions == null)
                        CustomActions = new List<Context>();

                    CustomActions.Add(context);
                    break;
            }
        }

        private void SignalStallOnAgent(ScenarioAgent agent)
        {
            agent.Stalled = true;
        }

        private PointF DisplayPointToCoordinates(Point display, Rectangle viewrect)
        {
            float x = (float)display.X / (float)viewrect.Width;
            float y = 1.0f - (float)display.Y / (float)viewrect.Height;

            x *= HorizontalUnitsVisible;
            y *= VerticalUnitsVisible;

            x -= HorizontalUnitsOffset;
            y -= VerticalUnitsOffset;

            return new PointF(x, y);
        }


        private Point CoordinatesToDisplayPoint(float x, float y, Rectangle rect)
        {
            x += HorizontalUnitsOffset;
            y += VerticalUnitsOffset;

            x /= HorizontalUnitsVisible;
            y /= VerticalUnitsVisible;

            return new Point((int)(x * (float)rect.Width), rect.Height - (int)(y * (float)rect.Height));
        }

        private Rectangle ToDisplayRect(IScenarioMember obj, Rectangle rect)
        {
            PointF center = obj.GetPosition();
            Point centerRender = CoordinatesToDisplayPoint(center.X, center.Y, rect);

            int width = (int)((float)rect.Width * obj.GetRadius() / (HorizontalUnitsVisible / 2.0f));
            int height = (int)((float)rect.Height * obj.GetRadius() / (VerticalUnitsVisible / 2.0f));

            return new Rectangle(centerRender.X - (width / 2), centerRender.Y - (height / 2), width, height);
        }

        private PointF ComputeVectorTowardsTarget(Context context)
        {
            PointF targetPoint = context.Target.GetPosition();
            float dx = targetPoint.X - context.ThinkingAgent.Position.X;
            float dy = targetPoint.Y - context.ThinkingAgent.Position.Y;

            var normal = Normalize(new PointF(dx, dy));
            return normal;
        }

        private PointF Normalize(PointF input)
        {
            float length = (float)Math.Sqrt(input.X * input.X + input.Y * input.Y);
            if (length < 0.001f)
                return new PointF(0.0f, 0.0f);

            float invlength = 1.0f / length;
            return new PointF(input.X * invlength, input.Y * invlength);
        }

        private float ClampToArrival(float start, float limit, float desired)
        {
            if (start <= limit)
            {
                if (desired > limit)
                    return limit;

                return desired;
            }
            else
            {
                if (desired < limit)
                    return limit;

                return desired;
            }
        }

        private float ClampToEscape(float start, float limit, float desired)
        {
            if (start <= limit)
            {
                if (desired > limit)
                    return limit;

                return desired + 0.04f - ((float)RandomNumbers.NextDouble() * 0.08f);
            }
            else
            {
                if (desired < limit)
                    return limit;

                return desired + 0.04f - ((float)RandomNumbers.NextDouble() * 0.08f);
            }
        }

        private float Distance(PointF a, PointF b)
        {
            float dx = b.X - a.X;
            float dy = b.Y - a.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            InitializeDrawingResources();
            RandomNumbers = new Random();
        }


        private void InitializeDrawingResources()
        {
            RenderPenDottedBlack = new Pen(Color.Black, 1.0f);
            RenderPenDottedBlack.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }


        private bool HitTest(IScenarioMember member, PointF simpt)
        {
            var simposition = member.GetPosition();

            float dx = simpt.X - simposition.X;
            float dy = simpt.Y - simposition.Y;

            float distanceSq = dx * dx + dy * dy;

            return (distanceSq <= member.GetRadius() * member.GetRadius());
        }


        public string GetInspectionText(Rectangle rect, Point pt)
        {
            var simpt = DisplayPointToCoordinates(pt, rect);

            foreach (var agent in Agents)
            {
                if (HitTest(agent, simpt))
                {
                    string positiontext = $"{agent.GetPosition()} R:{agent.GetRadius()}";

                    string decisiontext = "[Stalled]";
                    if (AgentDecisions != null && AgentDecisions.ContainsKey(agent))
                    {
                        if (AgentDecisions[agent].WinningContext != null)
                            decisiontext = AgentDecisions[agent].WinningContext.ToString();
                    }

                    return $"Agent: {agent.GetName()}\r\n\r\n{positiontext}\r\n{decisiontext}";
                }
            }

            foreach (var loc in Locations)
            {
                if (HitTest(loc, simpt))
                {
                    string positiontext = $"{loc.GetPosition()} R:{loc.GetRadius()}";
                    return $"Location: {loc.GetName()}\r\n{positiontext}";
                }
            }

            return null;
        }
    }
}
