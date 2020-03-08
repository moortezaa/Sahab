using Sahab_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop.Forms
{
    public partial class FrameForm : Form
    {
        private Frame Frame { get; set; }
        private bool OpenedForEdit { get; set; }
        public FrameForm()
        {
            InitializeComponent();
            KeyDown += FrameForm_KeyDown;
        }

        public DialogResult ShowForEdit(Frame frame)
        {
            Frame = frame;
            OpenedForEdit = true;
            NameTextBox.Text = Frame.Name;
            ScoreTextBox.Text = Frame.Score.ToString();
            if (ShowDialog() == DialogResult.OK)
            {
                Close();
                return DialogResult.OK;
            }
            else
            {
                Close();
                return DialogResult.Cancel;
            }
        }
        private void FrameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Button1_Click(sender, new EventArgs());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (OpenedForEdit)
            {
                var context = new AppDBContext();
                context.Frames.Attach(Frame);
                Frame.Name = NameTextBox.Text;
                Frame.Score = int.Parse(ScoreTextBox.Text);
                context.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            else
            {
                try
                {
                    var context = new AppDBContext();
                    var frame = new Frame()
                    {
                        Name = NameTextBox.Text,
                        Score = int.Parse(ScoreTextBox.Text)
                    };
                    context.Frames.Add(frame);
                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception)
                {
                    ScoreTextBox.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
