using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sahab_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sahab_Desktop.Forms
{
    public partial class WebSyncForm : Form
    {
        BackgroundWorker sendBgWorker;
        BackgroundWorker getBgWorker;
        public static int progress = 0;
        public static string message;
        public static bool ErrorAcured = false;
        private readonly WebSyncType webSyncType;
        public WebSyncForm(WebSyncType type)
        {
            webSyncType = type;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void WebSyncForm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = "آماده سازی برای همگام سازی";
            switch (webSyncType)
            {
                case WebSyncType.Send:
                    sendBgWorker = new BackgroundWorker();
                    sendBgWorker.WorkerReportsProgress = true;
                    sendBgWorker.DoWork += Send_Bg_DoWork;
                    sendBgWorker.RunWorkerCompleted += Bg_RunWorkerCompleted;
                    sendBgWorker.ProgressChanged += BgWorker_ProgressChanged;
                    sendBgWorker.RunWorkerAsync();
                    break;
                case WebSyncType.Get:
                    getBgWorker = new BackgroundWorker();
                    getBgWorker.WorkerReportsProgress = true;
                    getBgWorker.DoWork += Get_Bg_DoWork;
                    getBgWorker.RunWorkerCompleted += Bg_RunWorkerCompleted;
                    getBgWorker.ProgressChanged += BgWorker_ProgressChanged;
                    getBgWorker.RunWorkerAsync();
                    break;
                default:
                    break;
            }
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ErrorAcured)
            {
                var errorForm = new ErrorForm();
                errorForm.Message = message;

                errorForm.Show();
                message = "خطایی در اتصال رخ داده است. لطفا بعدا امتحان کنید";
                statusLabel.BackColor = Color.Red;
            }
            progressBar.Value = progress;
            statusLabel.Text = message;
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = progressBar.Maximum;
        }

        private void Get_Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                message = "آماده سازی برای همگام سازی";
                var context = new AppDBContext();
                var user = context.Users.First();

                var values = new { user = user };
                var content = JsonConvert.SerializeObject(values);

                var finalbyte = Encoding.UTF8.GetByteCount(content);
                var webRequest = WebRequest.Create("http://hadi-dev.ir/services/GetSahabTasks") as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.KeepAlive = true;
                webRequest.ContentType = "application/json";
                message = "ارسال درخواست به سرور";
                getBgWorker.ReportProgress(progress);

                var stream = webRequest.GetRequestStream();
                stream.Write(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetByteCount(content));

                progress = 10;
                message = "دریافت اطلاعات";
                getBgWorker.ReportProgress(progress);

                var webResponse = webRequest.GetResponse();
                var responseStream = webResponse.GetResponseStream();
                var responceStreamReader = new StreamReader(responseStream, Encoding.UTF8);

                var position = 0;
                var responseString = "";
                var contentLength = int.Parse(webResponse.Headers.Get("length"));
                while (!responceStreamReader.EndOfStream)
                {
                    responseString += (char)responceStreamReader.Read();
                    position++;
                    progress = (position / contentLength * 80) + 10;
                    message = "ذخیره اطلاعات";
                    getBgWorker.ReportProgress(progress);
                }
                var response = JsonConvert.DeserializeObject<GetSahabTaskRequest>(responseString);
                var parsedResponse = JsonConvert.DeserializeObject<AddSahabTaskRequest>(response.text);
                progress = 90;
                message = "ذخیره اطلاعات";
                getBgWorker.ReportProgress(progress);

                context.Tasks.AddRange(parsedResponse.tasks);
                context.SaveChanges();

                message = "پایان";
                getBgWorker.ReportProgress(progress);
            }
            catch (Exception ex)
            {
                var text = "";
                do
                {
                    text += $"{ex.Message}\n{ex.StackTrace}\n";
                    if (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                } while (ex.InnerException != null);
                message = text;
                ErrorAcured = true;
                getBgWorker.ReportProgress(progress);
            }
        }

        internal class GetSahabTaskRequest
        {
            public string text;
        }

        internal class AddSahabTaskRequest
        {
            public User user;
            public List<Task> tasks;
        }

        private void Send_Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                message = "آماده سازی برای همگام سازی";
                var context = new AppDBContext();
                var user = context.Users.First();
                var tasks = context.Tasks.AsQueryable();

                var values = new { user = user, tasks = tasks };
                var content = JsonConvert.SerializeObject(values);

                var finalbyte = Encoding.UTF8.GetByteCount(content);
                var webRequest = WebRequest.Create("http://hadi-dev.ir/services/AddSahabTasks") as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.KeepAlive = true;
                webRequest.ContentType = "application/json";

                var stream = webRequest.GetRequestStream();

                int bytesRead = 0;
                int bytesSoFar = 0;
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                while (bytesSoFar != finalbyte)
                {
                    bytesRead = (finalbyte - bytesSoFar) > 1024 ? 1024 : finalbyte - bytesSoFar;
                    stream.Write(buffer, bytesSoFar, bytesRead);
                    bytesSoFar += bytesRead;
                    progress = (int)(((long)bytesSoFar * 100.0f) / (long)finalbyte);
                    message = "ارسال تسک ها " + progress + "%";
                    sendBgWorker.ReportProgress(progress);
                }
                stream.Close();


                GetResponseDel d = new GetResponseDel(GetResponse);
                ResponseData data = new ResponseData { del = d };
                d.BeginInvoke(webRequest, EndGetResponse, data);
                progress = progressBar.Maximum;
                while (!webRequest.HaveResponse)
                {
                    message = "نهایی سازی";
                    Thread.Sleep(150);
                }

                webRequest = null;
                JObject responceQuery = JObject.Parse(data.responseString);
                message = responceQuery["text"].Value<string>();
                sendBgWorker.ReportProgress(progress);
            }
            catch (Exception ex)
            {
                var text = "";
                do
                {
                    text += $"{ex.Message}\n{ex.StackTrace}\n";
                    if (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                } while (ex.InnerException != null);
                message = text;
                ErrorAcured = true;
                sendBgWorker.ReportProgress(progress);
            }
        }

        delegate WebResponse GetResponseDel(HttpWebRequest webRequest);
        private WebResponse GetResponse(HttpWebRequest webRequest)
        {
            return webRequest.GetResponse();
        }

        class ResponseData
        {
            public GetResponseDel del { get; set; }
            public string responseString { get; set; }
        }

        private void EndGetResponse(IAsyncResult res)
        {
            ResponseData data = (ResponseData)res.AsyncState;
            GetResponseDel d = data.del;

            WebResponse r = d.EndInvoke(res);
            data.responseString = new StreamReader(r.GetResponseStream()).ReadToEnd();
        }

        public enum WebSyncType
        {
            Send,

            Get,
        }
    }
}
