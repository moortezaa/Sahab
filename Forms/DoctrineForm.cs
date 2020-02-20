﻿using Sahab_Desktop.Models;
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
    public partial class DoctrineForm : Form
    {
        public DoctrineForm()
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
                var doctrine = new Doctrine()
                {
                    Name = NameTextBox.Text,
                    Score = int.Parse(ScoreTextBox.Text)
                };
                context.Doctrines.Add(doctrine);
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
