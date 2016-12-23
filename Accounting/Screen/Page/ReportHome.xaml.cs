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
using Accounting.Screen.Report;
using Accounting.Screen.Transaction;

namespace Accounting.Screen.Page
{
    /// <summary>
    /// Interaction logic for ReportHome.xaml
    /// </summary>
    public partial class ReportHome : UserControl
    {
        public ReportHome()
        {
            InitializeComponent();
        }

        private void Report_MouseDown(object sender, MouseButtonEventArgs e)
        {
            String clickedLabel = ((Label) sender).Name.ToString();
            switch (clickedLabel)
            {
                case "TxRecords":
                    HomeContent.Open(new TransactionRecords());
                    break;
                case "ProfitLoss":
                case "BalanceSheet":
                case "TrialBalance":
                case "LedjerSummary":
                case "LedjerActivity":
                    HomeContent.Open(null);
                    break;
            }
        }
    }
}
