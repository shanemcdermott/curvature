﻿namespace Curvature.Widgets
{
    partial class EditWidgetParameterValue
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
            this.ParamNameLabel = new System.Windows.Forms.Label();
            this.ValueUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ParamNameLabel
            // 
            this.ParamNameLabel.AutoSize = true;
            this.ParamNameLabel.Location = new System.Drawing.Point(24, 9);
            this.ParamNameLabel.Name = "ParamNameLabel";
            this.ParamNameLabel.Size = new System.Drawing.Size(95, 13);
            this.ParamNameLabel.TabIndex = 0;
            this.ParamNameLabel.Text = "(Parameter Name):";
            this.ParamNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ValueUpDown
            // 
            this.ValueUpDown.DecimalPlaces = 3;
            this.ValueUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ValueUpDown.Location = new System.Drawing.Point(125, 6);
            this.ValueUpDown.Name = "ValueUpDown";
            this.ValueUpDown.Size = new System.Drawing.Size(137, 20);
            this.ValueUpDown.TabIndex = 1;
            this.ValueUpDown.ValueChanged += new System.EventHandler(this.ValueUpDown_ValueChanged);
            // 
            // EditWidgetParameterValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValueUpDown);
            this.Controls.Add(this.ParamNameLabel);
            this.Name = "EditWidgetParameterValue";
            this.Size = new System.Drawing.Size(270, 31);
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ParamNameLabel;
        private System.Windows.Forms.NumericUpDown ValueUpDown;
    }
}
