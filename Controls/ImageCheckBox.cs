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
        public event ImageCheckBoxCheckedChange CheckedChange;
        public delegate void ImageCheckBoxCheckedChange(bool isChecked);
        public bool Checked
        {
            get
            {
                return checkBox.Checked;
            }
            set
            {
                checkBox.Checked = value;
                PictureBox_Click(this, new EventArgs());
                PictureBox_Click(this, new EventArgs());
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
                checkBox.Checked = false;
                pictureBox.Image = UnCheckedImage;
            }
            else
            {
                checkBox.Checked = true;
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
            CheckedChange?.Invoke(checkBox.Checked);
        }
    }
}
