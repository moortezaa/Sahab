using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop.Controls
{
    public partial class ImageCheckBox : UserControl
    {
        public event EventHandler CheckedChange;
        public bool Checked
        {
            get
            {
                return checkBox.Checked;
            }
        }
        public Image UnCheckedImage { get; set; }
        public Image CheckedImage { get; set; }
        public ImageCheckBox()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                checkBox.CheckState = CheckState.Unchecked;
                pictureBox.Image = UnCheckedImage;
            }
            else
            {
                checkBox.CheckState = CheckState.Checked;
                pictureBox.Image = CheckedImage;
            }
        }

        public void RefreshImages()
        {
            if (checkBox.Checked)
            {
                pictureBox.Image = CheckedImage;
            }
            else
            {
                pictureBox.Image = UnCheckedImage;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChange?.Invoke(sender, e);
        }
    }
}
