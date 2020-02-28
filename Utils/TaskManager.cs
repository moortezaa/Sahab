using Sahab_Desktop.Forms;
using Sahab_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahab_Desktop.Utils
{
    public class TaskManager
    {

        public static void DoTaskRemovalOperation(Task task,DateTime showingInDate)
        {
            using (var context = new AppDBContext())
            {
                if (task.RepeatMethod != 0)
                {
                    var dialog = new CancelOr2OptionsDialog("این برنامه دارای تکرار است. آیا می خواهید از اینجا به بعد را پاک کنید یا فقط این مورد را پاک کنید؟",
                        "از اینجا به بعد",
                        "فقط همین");
                    if (dialog.Show() == CancelOr2OptionsDialogResult.Option1)
                    {
                        context.Tasks.Attach(task);
                        if (showingInDate.CompareTo(task.StartDate) == 0)
                        {
                            context.Tasks.Remove(task);
                        }
                        else
                        {
                            task.EndDate = task.Dates.Where(d => d.CompareTo(showingInDate) < 0).OrderByDescending(d => d).First();
                        }
                        context.SaveChanges();
                    }
                    else if (dialog.CancelOr2OptionsDialogResult == CancelOr2OptionsDialogResult.Option2)
                    {
                        if (showingInDate.CompareTo(task.StartDate) == 0)
                        {
                            context.Tasks.Attach(task);
                            task.StartDate = task.Dates.Where(d => d.CompareTo(task.StartDate) > 0).OrderBy(d => d).First();
                        }
                        else if (showingInDate.CompareTo(task.EndDate) == 0)
                        {
                            context.Tasks.Attach(task);
                            task.EndDate = task.Dates.Where(d => d.CompareTo(task.EndDate) < 0).OrderByDescending(d => d).First();
                        }
                        else
                        {
                            var newTask = new Task()
                            {
                                DaysOfWeek = task.DaysOfWeek,
                                SpecialDates = task.SpecialDates,
                                ContinuousTimes = task.ContinuousTimes,
                                Description = task.Description,
                                DiscreteTimes = task.DiscreteTimes,
                                EndDate = task.EndDate,
                                EndTime = task.EndTime,
                                Location = task.Location,
                                Peoples = task.Peoples,
                                RepeatMethod = task.RepeatMethod,
                                StartTime = task.StartTime,
                                TaskPriority = task.TaskPriority,
                                TaskPriorityScore = task.TaskPriorityScore,
                                Title = task.Title,
                                StartDate = task.Dates.Where(d => d.CompareTo(showingInDate) > 0).OrderBy(d => d).First()
                            };
                            context.Tasks.Add(newTask);

                            context.Tasks.Attach(task);
                            task.EndDate = task.Dates.Where(d => d.CompareTo(showingInDate) < 0).OrderByDescending(d => d).First();
                        }
                        context.SaveChanges();
                    }
                }
                else
                {
                    context.Tasks.Attach(task);
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
            }
        }
    }
}
