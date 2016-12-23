using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accounting.Screen.Page;

namespace Accounting.Screen.Report
{
    /// <summary>
    /// Interaction logic for TransactionRecords.xaml
    /// </summary>
    public partial class TransactionRecords : UserControl
    {
        public TransactionRecords()
        {
            InitializeComponent();
        }

        private void ViewRecord_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            Console.WriteLine("view link clicked");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeContent.Open(new ReportHome());
        }
    }
}
