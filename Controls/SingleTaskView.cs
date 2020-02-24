using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sahab_Desktop.Forms;

namespace Sahab_Desktop.Controls
{
    public partial class SingleTaskView : UserControl
    {
        public Models.Task Task { get; set; }
        public DateTime ShowingInDate { get; set; }
        public SingleTaskView(DateTime showingInDate)
        {
            ShowingInDate = showingInDate;
            InitializeComponent();
        }

        private void SingleTaskView_Load(object sender, EventArgs e)
        {
            RefreshSize();
            if (Task != null)
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

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new AppDBContext())
            {
                if (Task.RepeatMethod != 0)
                {
                    var dialog = new CancelOr2OptionsDialog("این برنامه دارای تکرار است. آیا می خواهید از اینجا به بعد را پاک کنید یا فقط این مورد را پاک کنید؟",
                        "از اینجا به بعد",
                        "فقط همین");
                    if (dialog.Show() == CancelOr2OptionsDialogResult.Option1)
                    {
                        context.Tasks.Attach(Task);
                        if (ShowingInDate.CompareTo(Task.StartDate) == 0)
                        {
                            context.Tasks.Remove(Task);
                        }
                        else
                        {
                            Task.EndDate = Task.Dates.Where(d => d.CompareTo(ShowingInDate) < 0).OrderByDescending(d => d).First();
                        }
                        context.SaveChanges();
                    }
                    else if (dialog.CancelOr2OptionsDialogResult == CancelOr2OptionsDialogResult.Option2)
                    {
                        if (ShowingInDate.CompareTo(Task.StartDate) == 0)
                        {
                            context.Tasks.Attach(Task);
                            Task.StartDate = Task.Dates.Where(d => d.CompareTo(Task.StartDate) > 0).OrderBy(d => d).First();
                        }
                        else if (ShowingInDate.CompareTo(Task.EndDate) == 0)
                        {
                            context.Tasks.Attach(Task);
                            Task.EndDate = Task.Dates.Where(d => d.CompareTo(Task.EndDate) < 0).OrderByDescending(d => d).First();
                        }
                        else
                        {
                            var task = new Models.Task()
                            {
                                ContinuousTimes = Task.ContinuousTimes,
                                Description = Task.Description,
                                DiscreteTimes = Task.DiscreteTimes,
                                EndDate = Task.EndDate,
                                EndTime = Task.EndTime,
                                Location = Task.Location,
                                Peoples = Task.Peoples,
                                RepeatMethod = Task.RepeatMethod,
                                StartTime = Task.StartTime,
                                TaskPriority = Task.TaskPriority,
                                TaskPriorityScore = Task.TaskPriorityScore,
                                Title = Task.Title,
                                StartDate = Task.Dates.Where(d => d.CompareTo(ShowingInDate) > 0).OrderBy(d => d).First()
                            };
                            context.Tasks.Add(task);

                            context.Tasks.Attach(Task);
                            Task.EndDate = Task.Dates.Where(d => d.CompareTo(ShowingInDate) < 0).OrderByDescending(d => d).First();
                        }
                        context.SaveChanges();
                    }
                }
                else
                {
                    context.Tasks.Attach(Task);
                    context.Tasks.Remove(Task);
                    context.SaveChanges();
                }
            }
        }
    }
}
