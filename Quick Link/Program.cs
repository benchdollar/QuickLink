using System;
using System.Threading;
using System.Windows.Forms;

namespace QuickLink
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "{6d5a148c-92e2-42ee-bf0e-f8cc887619fd}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new CustomApplicationContext());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Quick Link is already running.");
            }

        }
    }
}
