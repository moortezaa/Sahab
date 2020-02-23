namespace Sahab_Desktop.Controls
{
    partial class SingleTaskView
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.personsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel.Location = new System.Drawing.Point(98, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.titleLabel.Size = new System.Drawing.Size(52, 148);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locationLabel
            // 
            this.locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.locationLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.locationLabel.Location = new System.Drawing.Point(3, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.locationLabel.Size = new System.Drawing.Size(52, 148);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Location";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // personsLabel
            // 
            this.personsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.personsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personsLabel.Location = new System.Drawing.Point(52, 0);
            this.personsLabel.Name = "personsLabel";
            this.personsLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personsLabel.Size = new System.Drawing.Size(52, 148);
            this.personsLabel.TabIndex = 0;
            this.personsLabel.Text = "Persons, Persons";
            this.personsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SingleTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.personsLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "SingleTaskView";
            this.Size = new System.Drawing.Size(148, 148);
            this.Load += new System.EventHandler(this.SingleTaskView_Load);
            this.Resize += new System.EventHandler(this.SingleTaskView_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label personsLabel;
    }
}
