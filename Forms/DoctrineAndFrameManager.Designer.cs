namespace Sahab_Desktop.Forms
{
    partial class DoctrineAndFrameManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctrineAndFrameManager));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.framesAddButton = new System.Windows.Forms.Button();
            this.framesMoveDownButton = new System.Windows.Forms.Button();
            this.framesRemoveButton = new System.Windows.Forms.Button();
            this.framesMoveUpButton = new System.Windows.Forms.Button();
            this.framesEditButton = new System.Windows.Forms.Button();
            this.framesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.doctrinesAddButton = new System.Windows.Forms.Button();
            this.doctrinesMoveDownButton = new System.Windows.Forms.Button();
            this.doctrinesRemoveButton = new System.Windows.Forms.Button();
            this.doctrinesEditButton = new System.Windows.Forms.Button();
            this.doctrinesMoveUpButton = new System.Windows.Forms.Button();
            this.doctrinesListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(this.framesListBox);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.panel2);
            this.splitContainer.Panel2.Controls.Add(this.doctrinesListBox);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Size = new System.Drawing.Size(1048, 577);
            this.splitContainer.SplitterDistance = 528;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.framesAddButton);
            this.panel1.Controls.Add(this.framesMoveDownButton);
            this.panel1.Controls.Add(this.framesRemoveButton);
            this.panel1.Controls.Add(this.framesMoveUpButton);
            this.panel1.Controls.Add(this.framesEditButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(329, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 544);
            this.panel1.TabIndex = 3;
            // 
            // framesAddButton
            // 
            this.framesAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.framesAddButton.Location = new System.Drawing.Point(8, 4);
            this.framesAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.framesAddButton.Name = "framesAddButton";
            this.framesAddButton.Size = new System.Drawing.Size(183, 28);
            this.framesAddButton.TabIndex = 1;
            this.framesAddButton.Text = "افزودن";
            this.framesAddButton.UseVisualStyleBackColor = true;
            this.framesAddButton.Click += new System.EventHandler(this.FramesAddButton_Click);
            // 
            // framesMoveDownButton
            // 
            this.framesMoveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.framesMoveDownButton.Location = new System.Drawing.Point(8, 160);
            this.framesMoveDownButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.framesMoveDownButton.Name = "framesMoveDownButton";
            this.framesMoveDownButton.Size = new System.Drawing.Size(183, 28);
            this.framesMoveDownButton.TabIndex = 1;
            this.framesMoveDownButton.Text = "پایین بردن";
            this.framesMoveDownButton.UseVisualStyleBackColor = true;
            this.framesMoveDownButton.Click += new System.EventHandler(this.FramesMoveDownButton_Click);
            // 
            // framesRemoveButton
            // 
            this.framesRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.framesRemoveButton.Location = new System.Drawing.Point(8, 39);
            this.framesRemoveButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.framesRemoveButton.Name = "framesRemoveButton";
            this.framesRemoveButton.Size = new System.Drawing.Size(183, 28);
            this.framesRemoveButton.TabIndex = 1;
            this.framesRemoveButton.Text = "حذف";
            this.framesRemoveButton.UseVisualStyleBackColor = true;
            this.framesRemoveButton.Click += new System.EventHandler(this.FramesRemoveButton_Click);
            // 
            // framesMoveUpButton
            // 
            this.framesMoveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.framesMoveUpButton.Location = new System.Drawing.Point(8, 124);
            this.framesMoveUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.framesMoveUpButton.Name = "framesMoveUpButton";
            this.framesMoveUpButton.Size = new System.Drawing.Size(183, 28);
            this.framesMoveUpButton.TabIndex = 1;
            this.framesMoveUpButton.Text = "بالا بردن";
            this.framesMoveUpButton.UseVisualStyleBackColor = true;
            this.framesMoveUpButton.Click += new System.EventHandler(this.FramesMoveUpButton_Click);
            // 
            // framesEditButton
            // 
            this.framesEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.framesEditButton.Location = new System.Drawing.Point(8, 75);
            this.framesEditButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.framesEditButton.Name = "framesEditButton";
            this.framesEditButton.Size = new System.Drawing.Size(183, 28);
            this.framesEditButton.TabIndex = 1;
            this.framesEditButton.Text = "ویرایش";
            this.framesEditButton.UseVisualStyleBackColor = true;
            this.framesEditButton.Click += new System.EventHandler(this.FramesEditButton_Click);
            // 
            // framesListBox
            // 
            this.framesListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.framesListBox.FormattingEnabled = true;
            this.framesListBox.ItemHeight = 16;
            this.framesListBox.Location = new System.Drawing.Point(0, 33);
            this.framesListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.framesListBox.Name = "framesListBox";
            this.framesListBox.Size = new System.Drawing.Size(329, 544);
            this.framesListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "چهارچوب ها";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.doctrinesAddButton);
            this.panel2.Controls.Add(this.doctrinesMoveDownButton);
            this.panel2.Controls.Add(this.doctrinesRemoveButton);
            this.panel2.Controls.Add(this.doctrinesEditButton);
            this.panel2.Controls.Add(this.doctrinesMoveUpButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(337, 33);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 544);
            this.panel2.TabIndex = 3;
            // 
            // doctrinesAddButton
            // 
            this.doctrinesAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctrinesAddButton.Location = new System.Drawing.Point(8, 4);
            this.doctrinesAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.doctrinesAddButton.Name = "doctrinesAddButton";
            this.doctrinesAddButton.Size = new System.Drawing.Size(162, 28);
            this.doctrinesAddButton.TabIndex = 1;
            this.doctrinesAddButton.Text = "افزودن";
            this.doctrinesAddButton.UseVisualStyleBackColor = true;
            this.doctrinesAddButton.Click += new System.EventHandler(this.DoctrinesAddButton_Click);
            // 
            // doctrinesMoveDownButton
            // 
            this.doctrinesMoveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctrinesMoveDownButton.Location = new System.Drawing.Point(8, 160);
            this.doctrinesMoveDownButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.doctrinesMoveDownButton.Name = "doctrinesMoveDownButton";
            this.doctrinesMoveDownButton.Size = new System.Drawing.Size(162, 28);
            this.doctrinesMoveDownButton.TabIndex = 1;
            this.doctrinesMoveDownButton.Text = "پایین بردن";
            this.doctrinesMoveDownButton.UseVisualStyleBackColor = true;
            this.doctrinesMoveDownButton.Click += new System.EventHandler(this.DoctrinesMoveDownButton_Click);
            // 
            // doctrinesRemoveButton
            // 
            this.doctrinesRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctrinesRemoveButton.Location = new System.Drawing.Point(8, 39);
            this.doctrinesRemoveButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.doctrinesRemoveButton.Name = "doctrinesRemoveButton";
            this.doctrinesRemoveButton.Size = new System.Drawing.Size(162, 28);
            this.doctrinesRemoveButton.TabIndex = 1;
            this.doctrinesRemoveButton.Text = "حذف";
            this.doctrinesRemoveButton.UseVisualStyleBackColor = true;
            this.doctrinesRemoveButton.Click += new System.EventHandler(this.DoctrinesRemoveButton_Click);
            // 
            // doctrinesEditButton
            // 
            this.doctrinesEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctrinesEditButton.Location = new System.Drawing.Point(8, 75);
            this.doctrinesEditButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.doctrinesEditButton.Name = "doctrinesEditButton";
            this.doctrinesEditButton.Size = new System.Drawing.Size(162, 28);
            this.doctrinesEditButton.TabIndex = 1;
            this.doctrinesEditButton.Text = "ویرایش";
            this.doctrinesEditButton.UseVisualStyleBackColor = true;
            this.doctrinesEditButton.Click += new System.EventHandler(this.DoctrinesEditButton_Click);
            // 
            // doctrinesMoveUpButton
            // 
            this.doctrinesMoveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doctrinesMoveUpButton.Location = new System.Drawing.Point(8, 124);
            this.doctrinesMoveUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.doctrinesMoveUpButton.Name = "doctrinesMoveUpButton";
            this.doctrinesMoveUpButton.Size = new System.Drawing.Size(162, 28);
            this.doctrinesMoveUpButton.TabIndex = 1;
            this.doctrinesMoveUpButton.Text = "بالا بردن";
            this.doctrinesMoveUpButton.UseVisualStyleBackColor = true;
            this.doctrinesMoveUpButton.Click += new System.EventHandler(this.DoctrinesMoveUpButton_Click);
            // 
            // doctrinesListBox
            // 
            this.doctrinesListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.doctrinesListBox.FormattingEnabled = true;
            this.doctrinesListBox.ItemHeight = 16;
            this.doctrinesListBox.Location = new System.Drawing.Point(0, 33);
            this.doctrinesListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.doctrinesListBox.Name = "doctrinesListBox";
            this.doctrinesListBox.Size = new System.Drawing.Size(337, 544);
            this.doctrinesListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(515, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "اصول";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoctrineAndFrameManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 577);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DoctrineAndFrameManager";
            this.Text = "مدیریت اصول و چهارچوب ها";
            this.Load += new System.EventHandler(this.DoctrineAndFrameManager_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox framesListBox;
        private System.Windows.Forms.ListBox doctrinesListBox;
        private System.Windows.Forms.Button framesMoveDownButton;
        private System.Windows.Forms.Button framesMoveUpButton;
        private System.Windows.Forms.Button framesEditButton;
        private System.Windows.Forms.Button framesRemoveButton;
        private System.Windows.Forms.Button framesAddButton;
        private System.Windows.Forms.Button doctrinesMoveDownButton;
        private System.Windows.Forms.Button doctrinesMoveUpButton;
        private System.Windows.Forms.Button doctrinesAddButton;
        private System.Windows.Forms.Button doctrinesEditButton;
        private System.Windows.Forms.Button doctrinesRemoveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}