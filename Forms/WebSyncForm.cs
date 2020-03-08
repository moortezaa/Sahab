using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop.Forms
{
    public partial class WebSyncForm : Form
    {
        public WebSyncForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void WebSyncForm_Shown(object sender, EventArgs e)
        {
            Thread childThread = new Thread(Sync);
            childThread.Start();
        }

        public void Sync()
        {
            statusLabel.Text = "آغاز همگام سازی";
        }
    }
}
