﻿namespace Curvature
{
    partial class EditWidgetBehavior
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Considerations", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Bonuses", System.Windows.Forms.HorizontalAlignment.Left);
            this.VerticalSplit = new System.Windows.Forms.SplitContainer();
            this.CanTargetOthersCheckBox = new System.Windows.Forms.CheckBox();
            this.CanTargetSelfCheckBox = new System.Windows.Forms.CheckBox();
            this.ActionComboBox = new System.Windows.Forms.ComboBox();
            this.BreakdownGroupBox = new System.Windows.Forms.GroupBox();
            this.FinalScoreLabel = new System.Windows.Forms.Label();
            this.ScoreListView = new System.Windows.Forms.ListView();
            this.ScoreColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DescriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MomentumBonusCheckBox = new System.Windows.Forms.CheckBox();
            this.CompensationCheckBox = new System.Windows.Forms.CheckBox();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.BehaviorWeightEditBox = new System.Windows.Forms.NumericUpDown();
            this.BehaviorSplitContainer = new System.Windows.Forms.SplitContainer();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.InputFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ConsiderationScoreGroupBox = new System.Windows.Forms.GroupBox();
            this.ScoreLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NameEditWidget = new Curvature.EditWidgetName();
            this.CustomPayloadLabel = new System.Windows.Forms.Label();
            this.CustomPayload = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSplit)).BeginInit();
            this.VerticalSplit.Panel1.SuspendLayout();
            this.VerticalSplit.Panel2.SuspendLayout();
            this.VerticalSplit.SuspendLayout();
            this.BreakdownGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorWeightEditBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorSplitContainer)).BeginInit();
            this.BehaviorSplitContainer.Panel1.SuspendLayout();
            this.BehaviorSplitContainer.Panel2.SuspendLayout();
            this.BehaviorSplitContainer.SuspendLayout();
            this.InputGroupBox.SuspendLayout();
            this.ConsiderationScoreGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalSplit
            // 
            this.VerticalSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VerticalSplit.Location = new System.Drawing.Point(3, 36);
            this.VerticalSplit.Name = "VerticalSplit";
            // 
            // VerticalSplit.Panel1
            // 
            this.VerticalSplit.Panel1.Controls.Add(this.CustomPayload);
            this.VerticalSplit.Panel1.Controls.Add(this.CustomPayloadLabel);
            this.VerticalSplit.Panel1.Controls.Add(this.CanTargetOthersCheckBox);
            this.VerticalSplit.Panel1.Controls.Add(this.CanTargetSelfCheckBox);
            this.VerticalSplit.Panel1.Controls.Add(this.ActionComboBox);
            this.VerticalSplit.Panel1.Controls.Add(this.BreakdownGroupBox);
            // 
            // VerticalSplit.Panel2
            // 
            this.VerticalSplit.Panel2.Controls.Add(this.BehaviorSplitContainer);
            this.VerticalSplit.Size = new System.Drawing.Size(719, 379);
            this.VerticalSplit.SplitterDistance = 300;
            this.VerticalSplit.TabIndex = 1;
            // 
            // CanTargetOthersCheckBox
            // 
            this.CanTargetOthersCheckBox.AutoSize = true;
            this.CanTargetOthersCheckBox.Location = new System.Drawing.Point(107, 27);
            this.CanTargetOthersCheckBox.Name = "CanTargetOthersCheckBox";
            this.CanTargetOthersCheckBox.Size = new System.Drawing.Size(113, 17);
            this.CanTargetOthersCheckBox.TabIndex = 4;
            this.CanTargetOthersCheckBox.Text = "Can Target Others";
            this.CanTargetOthersCheckBox.UseVisualStyleBackColor = true;
            this.CanTargetOthersCheckBox.CheckedChanged += new System.EventHandler(this.CanTargetOthersCheckBox_CheckedChanged);
            // 
            // CanTargetSelfCheckBox
            // 
            this.CanTargetSelfCheckBox.AutoSize = true;
            this.CanTargetSelfCheckBox.Location = new System.Drawing.Point(1, 27);
            this.CanTargetSelfCheckBox.Name = "CanTargetSelfCheckBox";
            this.CanTargetSelfCheckBox.Size = new System.Drawing.Size(100, 17);
            this.CanTargetSelfCheckBox.TabIndex = 3;
            this.CanTargetSelfCheckBox.Text = "Can Target Self";
            this.CanTargetSelfCheckBox.UseVisualStyleBackColor = true;
            this.CanTargetSelfCheckBox.CheckedChanged += new System.EventHandler(this.CanTargetSelfCheckBox_CheckedChanged);
            // 
            // ActionComboBox
            // 
            this.ActionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionComboBox.FormattingEnabled = true;
            this.ActionComboBox.Location = new System.Drawing.Point(1, 0);
            this.ActionComboBox.Name = "ActionComboBox";
            this.ActionComboBox.Size = new System.Drawing.Size(296, 21);
            this.ActionComboBox.TabIndex = 2;
            this.ActionComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionComboBox_SelectedIndexChanged);
            // 
            // BreakdownGroupBox
            // 
            this.BreakdownGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BreakdownGroupBox.Controls.Add(this.FinalScoreLabel);
            this.BreakdownGroupBox.Controls.Add(this.ScoreListView);
            this.BreakdownGroupBox.Controls.Add(this.MomentumBonusCheckBox);
            this.BreakdownGroupBox.Controls.Add(this.CompensationCheckBox);
            this.BreakdownGroupBox.Controls.Add(this.WeightLabel);
            this.BreakdownGroupBox.Controls.Add(this.BehaviorWeightEditBox);
            this.BreakdownGroupBox.Location = new System.Drawing.Point(0, 77);
            this.BreakdownGroupBox.Name = "BreakdownGroupBox";
            this.BreakdownGroupBox.Size = new System.Drawing.Size(297, 302);
            this.BreakdownGroupBox.TabIndex = 1;
            this.BreakdownGroupBox.TabStop = false;
            this.BreakdownGroupBox.Text = "Scoring Breakdown";
            // 
            // FinalScoreLabel
            // 
            this.FinalScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FinalScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalScoreLabel.Location = new System.Drawing.Point(9, 260);
            this.FinalScoreLabel.Name = "FinalScoreLabel";
            this.FinalScoreLabel.Size = new System.Drawing.Size(282, 30);
            this.FinalScoreLabel.TabIndex = 5;
            this.FinalScoreLabel.Text = "Final Score = 0.0";
            this.FinalScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreListView
            // 
            this.ScoreListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ScoreColumnHeader,
            this.DescriptionColumnHeader});
            listViewGroup3.Header = "Considerations";
            listViewGroup3.Name = "ConsiderationGroup";
            listViewGroup4.Header = "Bonuses";
            listViewGroup4.Name = "BonusGroup";
            this.ScoreListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.ScoreListView.Location = new System.Drawing.Point(6, 91);
            this.ScoreListView.Name = "ScoreListView";
            this.ScoreListView.Size = new System.Drawing.Size(285, 162);
            this.ScoreListView.TabIndex = 4;
            this.ScoreListView.UseCompatibleStateImageBehavior = false;
            this.ScoreListView.View = System.Windows.Forms.View.Details;
            // 
            // ScoreColumnHeader
            // 
            this.ScoreColumnHeader.Text = "Score";
            // 
            // DescriptionColumnHeader
            // 
            this.DescriptionColumnHeader.Text = "Description";
            this.DescriptionColumnHeader.Width = 120;
            // 
            // MomentumBonusCheckBox
            // 
            this.MomentumBonusCheckBox.AutoSize = true;
            this.MomentumBonusCheckBox.Location = new System.Drawing.Point(9, 68);
            this.MomentumBonusCheckBox.Name = "MomentumBonusCheckBox";
            this.MomentumBonusCheckBox.Size = new System.Drawing.Size(147, 17);
            this.MomentumBonusCheckBox.TabIndex = 3;
            this.MomentumBonusCheckBox.Text = "Include momentum bonus";
            this.MomentumBonusCheckBox.UseVisualStyleBackColor = true;
            // 
            // CompensationCheckBox
            // 
            this.CompensationCheckBox.AutoSize = true;
            this.CompensationCheckBox.Checked = true;
            this.CompensationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompensationCheckBox.Location = new System.Drawing.Point(9, 45);
            this.CompensationCheckBox.Name = "CompensationCheckBox";
            this.CompensationCheckBox.Size = new System.Drawing.Size(151, 17);
            this.CompensationCheckBox.TabIndex = 2;
            this.CompensationCheckBox.Text = "Use compensation formula";
            this.CompensationCheckBox.UseVisualStyleBackColor = true;
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(6, 22);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(89, 13);
            this.WeightLabel.TabIndex = 1;
            this.WeightLabel.Text = "Behavior Weight:";
            // 
            // BehaviorWeightEditBox
            // 
            this.BehaviorWeightEditBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BehaviorWeightEditBox.DecimalPlaces = 3;
            this.BehaviorWeightEditBox.Location = new System.Drawing.Point(101, 19);
            this.BehaviorWeightEditBox.Name = "BehaviorWeightEditBox";
            this.BehaviorWeightEditBox.Size = new System.Drawing.Size(190, 20);
            this.BehaviorWeightEditBox.TabIndex = 0;
            this.BehaviorWeightEditBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BehaviorSplitContainer
            // 
            this.BehaviorSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BehaviorSplitContainer.Location = new System.Drawing.Point(-1, 0);
            this.BehaviorSplitContainer.Name = "BehaviorSplitContainer";
            this.BehaviorSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BehaviorSplitContainer.Panel1
            // 
            this.BehaviorSplitContainer.Panel1.Controls.Add(this.InputGroupBox);
            // 
            // BehaviorSplitContainer.Panel2
            // 
            this.BehaviorSplitContainer.Panel2.Controls.Add(this.ConsiderationScoreGroupBox);
            this.BehaviorSplitContainer.Size = new System.Drawing.Size(419, 376);
            this.BehaviorSplitContainer.SplitterDistance = 166;
            this.BehaviorSplitContainer.TabIndex = 5;
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputGroupBox.Controls.Add(this.InputFlowPanel);
            this.InputGroupBox.Location = new System.Drawing.Point(4, 3);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(412, 160);
            this.InputGroupBox.TabIndex = 2;
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.Text = "Inputs";
            // 
            // InputFlowPanel
            // 
            this.InputFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFlowPanel.AutoScroll = true;
            this.InputFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.InputFlowPanel.Location = new System.Drawing.Point(6, 19);
            this.InputFlowPanel.Name = "InputFlowPanel";
            this.InputFlowPanel.Size = new System.Drawing.Size(400, 135);
            this.InputFlowPanel.TabIndex = 0;
            // 
            // ConsiderationScoreGroupBox
            // 
            this.ConsiderationScoreGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsiderationScoreGroupBox.Controls.Add(this.ScoreLayoutPanel);
            this.ConsiderationScoreGroupBox.Location = new System.Drawing.Point(4, 3);
            this.ConsiderationScoreGroupBox.Name = "ConsiderationScoreGroupBox";
            this.ConsiderationScoreGroupBox.Size = new System.Drawing.Size(412, 206);
            this.ConsiderationScoreGroupBox.TabIndex = 0;
            this.ConsiderationScoreGroupBox.TabStop = false;
            this.ConsiderationScoreGroupBox.Text = "Consideration Scores";
            // 
            // ScoreLayoutPanel
            // 
            this.ScoreLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreLayoutPanel.AutoScroll = true;
            this.ScoreLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ScoreLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.ScoreLayoutPanel.Name = "ScoreLayoutPanel";
            this.ScoreLayoutPanel.Size = new System.Drawing.Size(400, 181);
            this.ScoreLayoutPanel.TabIndex = 0;
            // 
            // NameEditWidget
            // 
            this.NameEditWidget.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameEditWidget.Location = new System.Drawing.Point(0, 0);
            this.NameEditWidget.Name = "NameEditWidget";
            this.NameEditWidget.Size = new System.Drawing.Size(725, 30);
            this.NameEditWidget.TabIndex = 2;
            // 
            // CustomPayloadLabel
            // 
            this.CustomPayloadLabel.AutoSize = true;
            this.CustomPayloadLabel.Location = new System.Drawing.Point(3, 53);
            this.CustomPayloadLabel.Name = "CustomPayloadLabel";
            this.CustomPayloadLabel.Size = new System.Drawing.Size(69, 13);
            this.CustomPayloadLabel.TabIndex = 5;
            this.CustomPayloadLabel.Text = "Custom Text:";
            // 
            // CustomPayload
            // 
            this.CustomPayload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomPayload.Location = new System.Drawing.Point(78, 50);
            this.CustomPayload.Name = "CustomPayload";
            this.CustomPayload.Size = new System.Drawing.Size(213, 20);
            this.CustomPayload.TabIndex = 6;
            this.CustomPayload.TextChanged += new System.EventHandler(this.CustomPayload_TextChanged);
            // 
            // EditWidgetBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameEditWidget);
            this.Controls.Add(this.VerticalSplit);
            this.Name = "EditWidgetBehavior";
            this.Size = new System.Drawing.Size(725, 418);
            this.VerticalSplit.Panel1.ResumeLayout(false);
            this.VerticalSplit.Panel1.PerformLayout();
            this.VerticalSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSplit)).EndInit();
            this.VerticalSplit.ResumeLayout(false);
            this.BreakdownGroupBox.ResumeLayout(false);
            this.BreakdownGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorWeightEditBox)).EndInit();
            this.BehaviorSplitContainer.Panel1.ResumeLayout(false);
            this.BehaviorSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorSplitContainer)).EndInit();
            this.BehaviorSplitContainer.ResumeLayout(false);
            this.InputGroupBox.ResumeLayout(false);
            this.ConsiderationScoreGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer VerticalSplit;
        private System.Windows.Forms.GroupBox BreakdownGroupBox;
        private System.Windows.Forms.Label FinalScoreLabel;
        private System.Windows.Forms.ListView ScoreListView;
        private System.Windows.Forms.ColumnHeader ScoreColumnHeader;
        private System.Windows.Forms.ColumnHeader DescriptionColumnHeader;
        private System.Windows.Forms.CheckBox MomentumBonusCheckBox;
        private System.Windows.Forms.CheckBox CompensationCheckBox;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.NumericUpDown BehaviorWeightEditBox;
        private System.Windows.Forms.SplitContainer BehaviorSplitContainer;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.FlowLayoutPanel InputFlowPanel;
        private System.Windows.Forms.GroupBox ConsiderationScoreGroupBox;
        private System.Windows.Forms.FlowLayoutPanel ScoreLayoutPanel;
        private System.Windows.Forms.ComboBox ActionComboBox;
        private System.Windows.Forms.CheckBox CanTargetSelfCheckBox;
        private System.Windows.Forms.CheckBox CanTargetOthersCheckBox;
        private EditWidgetName NameEditWidget;
        private System.Windows.Forms.Label CustomPayloadLabel;
        private System.Windows.Forms.TextBox CustomPayload;
    }
}
