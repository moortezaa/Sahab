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
        public FrameForm()
        {
            InitializeComponent();
            KeyDown += FrameForm_KeyDown;
        }

        private void FrameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Button1_Click(sender, new EventArgs());
        }

        private void Button1_Click(object sender, EventArgs e)
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

        private void ScoreTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
