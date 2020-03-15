using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sahab_Desktop.Forms;

namespace Sahab_Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                var errorForm = new ErrorForm();
                var error = e;
                var message = "";
                do
                {
                    message += $"{e.Message}\n{e.StackTrace}\n";
                    if (error.InnerException!=null)
                    {
                        error = error.InnerException;
                    }
                } while (error.InnerException!=null);
                errorForm.Message = message;

                Application.Run(errorForm);
            }
        }
    }
}
