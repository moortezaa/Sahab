﻿namespace Sahab_Desktop.Controls
{
    partial class DailyTaskViewer
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nowIndicatorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // nowIndicatorLabel
            // 
            this.nowIndicatorLabel.BackColor = System.Drawing.Color.Red;
            this.nowIndicatorLabel.Location = new System.Drawing.Point(4, 102);
            this.nowIndicatorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nowIndicatorLabel.Name = "nowIndicatorLabel";
            this.nowIndicatorLabel.Size = new System.Drawing.Size(185, 4);
            this.nowIndicatorLabel.TabIndex = 0;
            // 
            // DailyTaskViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nowIndicatorLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DailyTaskViewer";
            this.Size = new System.Drawing.Size(200, 185);
            this.Load += new System.EventHandler(this.DailyTaskViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label nowIndicatorLabel;
    }
}
