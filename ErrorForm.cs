using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop
{
    public partial class ErrorForm : Form
    {
        public string Message
        {
            set
            {
                textLabel.Text = value;
            }
        }
        public ErrorForm()
        {
            InitializeComponent();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var senderEmail = new MailAddress("donotreply@hadi-dev.ir", "Sahab DesktopBug");
                var receiverEmail = new MailAddress("moortezaa.1378.ma@gmail.com", "Receiver");
                var password = "fpikdr$j6Loustzgnwvb";
                var sub = "Bug Report";
                var body = textLabel.Text;
                var smtp = new SmtpClient
                {
                    Host = "mail.hadi-dev.ir",
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
