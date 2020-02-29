namespace Sahab_Desktop.Controls
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
            this.nowIndicatorLabel.Location = new System.Drawing.Point(3, 83);
            this.nowIndicatorLabel.Name = "nowIndicatorLabel";
            this.nowIndicatorLabel.Size = new System.Drawing.Size(139, 3);
            this.nowIndicatorLabel.TabIndex = 0;
            // 
            // DailyTaskViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nowIndicatorLabel);
            this.Name = "DailyTaskViewer";
            this.Load += new System.EventHandler(this.DailyTaskViewer_Load);
            this.Resize += new System.EventHandler(this.DailyTaskViewer_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label nowIndicatorLabel;
    }
}
