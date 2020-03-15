using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop.Forms
{
    public partial class LinkAccountForm : Form
    {
        public LinkAccountForm()
        {
            InitializeComponent();
        }

        private async void LinkButton_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var client = new HttpClient();
                var values = new { Email = emailTextBox.Text, Password = passTextBox.Text };
                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://hadi-dev.ir/services/Link", content);

                var responceContent = await response.Content.ReadAsStringAsync();
                statusLabel.Text = JObject.Parse(responceContent)["text"].Value<string>();
                if (statusLabel.Text == "OK")
                {
                    using (var context = new AppDBContext())
                    {
                        var user = context.Users.First();
                        user.UserName = emailTextBox.Text;
                        context.SaveChanges();
                    }
                    statusLabel.Text = "شما متصل شدید";
                    statusLabel.BackColor = Color.LimeGreen;
                    statusLabel.ForeColor = Color.Green;
                }
                else if (statusLabel.Text == "UserNotFound")
                {
                    statusLabel.Text = "کاربر پیدا نشد";
                    statusLabel.ForeColor = Color.Red;
                }
                else if (statusLabel.Text == "WrongPass")
                {
                    statusLabel.Text = "رمز اشتباه است";
                    statusLabel.ForeColor = Color.Red;
                }
                else
                {
                    statusLabel.Text = "مشکل در اتصال به سرور";
                    statusLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                statusLabel.Text = "مشکل در اتصال به سرور";
                statusLabel.ForeColor = Color.Red;
            }
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;

            System.Diagnostics.Process.Start("http://hadi-dev.ir/user/create");
        }
    }
}
