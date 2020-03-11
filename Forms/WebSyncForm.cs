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
    public partial class WebSyncForm : Form
    {
        public WebSyncForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private async void WebSyncForm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = "آغاز همگام سازی";
            var context = new AppDBContext();
            var user = context.Users.First();
            var tasks = context.Tasks.AsQueryable();
            var client = new HttpClient();
            var values = new { user = user, tasks = tasks };
            var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://hadi-dev.ir/services/AddSahabTasks", content);

            var responceContent = await response.Content.ReadAsStringAsync();
            statusLabel.Text = JObject.Parse(responceContent)["text"].Value<string>();
        }
    }
}
