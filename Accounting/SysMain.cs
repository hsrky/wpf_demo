using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Accounting.Screen;
using Accounting.Model;
using Accounting.Screen.Page;

namespace Accounting
{
    internal class SysMain
    {
        private static void Main()
        {
            var c = new TestChartOfAccounts();
            c.Read();
            Console.WriteLine("Hello from C#!!");
            var thread = new Thread(new ThreadStart(ShowScreen));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            Console.Write("END");
        }

        private static void ShowScreen()
        {//http://stackoverflow.com/questions/4183622/the-calling-thread-must-be-sta-because-many-ui-components-require-this-in-wpf
            try
            {
                //var screen = new HomeScreen();
                //var screen = new ChartOfAccountsWin();
                //screen.Show();
                //screen.Closed += (s, e) => System.Windows.Threading.Dispatcher.ExitAllFrames();
                //System.Windows.Threading.Dispatcher.Run();
                Console.WriteLine("ShowScreen...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
