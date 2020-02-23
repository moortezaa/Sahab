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
    public partial class SingleTaskView : UserControl
    {
        public Models.Task Task { get; set; }
        public SingleTaskView()
        {
            InitializeComponent();
        }

        private void SingleTaskView_Load(object sender, EventArgs e)
        {
            RefreshSize();
            if (Task!=null)
            {
                titleLabel.Text = Task.Title;
                personsLabel.Text = Task.Peoples;
                locationLabel.Text = Task.Location;
            }
        }

        private void SingleTaskView_Resize(object sender, EventArgs e)
        {
            RefreshSize();
        }

        private void RefreshSize()
        {
            int width = Width / 3;
            locationLabel.Width = width;
            locationLabel.Left = 0;
            personsLabel.Width = width;
            personsLabel.Left = width;
            titleLabel.Width = width;
            titleLabel.Left = width * 2;
        }
    }
}
