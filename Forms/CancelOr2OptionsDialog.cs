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
    public partial class CancelOr2OptionsDialog : Form
    {
        public CancelOr2OptionsDialogResult CancelOr2OptionsDialogResult { get; set; }
        public CancelOr2OptionsDialog(string description,string option1,string option2)
        {
            InitializeComponent();
            textLabel.Text = description;
            option1Button.Text = option1;
            option2Button.Text = option2;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CancelOr2OptionsDialogResult = CancelOr2OptionsDialogResult.Cancel;
            Close();
        }

        private void Option1Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CancelOr2OptionsDialogResult = CancelOr2OptionsDialogResult.Option1;
            Close();
        }

        private void Option2Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CancelOr2OptionsDialogResult = CancelOr2OptionsDialogResult.Option2;
            Close();
        }

        public new CancelOr2OptionsDialogResult Show()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return CancelOr2OptionsDialogResult;
            }
            else
            {
                return CancelOr2OptionsDialogResult.Cancel;
            }
        }
    }
    public enum CancelOr2OptionsDialogResult
    {
        Cancel,
        Option1,
        Option2,
    }
}
