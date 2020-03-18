namespace Sahab_Desktop.Forms
{
    partial class CancelOr2OptionsDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelOr2OptionsDialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.option1Button = new System.Windows.Forms.Button();
            this.option2Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sahab_Desktop.Properties.Resources.index;
            this.pictureBox1.Location = new System.Drawing.Point(17, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(156, 59);
            this.textLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textLabel.Name = "textLabel";
            this.textLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textLabel.Size = new System.Drawing.Size(519, 68);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "label1";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(569, 144);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "لغو";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // option1Button
            // 
            this.option1Button.Location = new System.Drawing.Point(461, 144);
            this.option1Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.option1Button.Name = "option1Button";
            this.option1Button.Size = new System.Drawing.Size(100, 28);
            this.option1Button.TabIndex = 2;
            this.option1Button.Text = "option1";
            this.option1Button.UseVisualStyleBackColor = true;
            this.option1Button.Click += new System.EventHandler(this.Option1Button_Click);
            // 
            // option2Button
            // 
            this.option2Button.Location = new System.Drawing.Point(353, 144);
            this.option2Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.option2Button.Name = "option2Button";
            this.option2Button.Size = new System.Drawing.Size(100, 28);
            this.option2Button.TabIndex = 2;
            this.option2Button.Text = "option2";
            this.option2Button.UseVisualStyleBackColor = true;
            this.option2Button.Click += new System.EventHandler(this.Option2Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(67, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "هشدار";
            // 
            // CancelOr2OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 196);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.option2Button);
            this.Controls.Add(this.option1Button);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CancelOr2OptionsDialog";
            this.Text = "هشدار";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button option1Button;
        private System.Windows.Forms.Button option2Button;
        private System.Windows.Forms.Label label1;
    }
}