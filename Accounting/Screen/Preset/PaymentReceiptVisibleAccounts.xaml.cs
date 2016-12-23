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

namespace Accounting.Screen.Preset
{
    /// <summary>
    /// Interaction logic for PaymentReceiptVisibleAccounts.xaml
    /// </summary>
    public partial class PaymentReceiptVisibleAccounts : UserControl
    {
        private readonly AdvanceMenu _parent;
        public PaymentReceiptVisibleAccounts(AdvanceMenu parent)
        {
            _parent = parent;
            InitializeComponent();
            var paymentCreditList = new List<PaymentCredit>();
            paymentCreditList.Add(new PaymentCredit() { AccountName = "Test 001" });
            paymentCreditList.Add(new PaymentCredit() { AccountName = "Test 002" });
            paymentCreditList.Add(new PaymentCredit() { AccountName = "Test 003" });
            PaymentCreditDataGrid.ItemsSource = paymentCreditList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _parent.Reload();
        }

        private void DG_PaymentCredit_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            PaymentCredit paymentCredit = ((FrameworkElement) sender).DataContext as PaymentCredit;
            if (paymentCredit == null) return;
            Console.WriteLine(paymentCredit.Id + " " + paymentCredit.AccountName);
        }

        private void DG_PaymentDebit_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            PaymentCredit paymentCredit = ((FrameworkElement)sender).DataContext as PaymentCredit;
            if (paymentCredit == null) return;
            Console.WriteLine(paymentCredit.Id + " " + paymentCredit.AccountName);
        }

        private void DG_PaymentTax_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            PaymentCredit paymentCredit = ((FrameworkElement)sender).DataContext as PaymentCredit;
            if (paymentCredit == null) return;
            Console.WriteLine(paymentCredit.Id + " " + paymentCredit.AccountName);
        }

        private void DG_ReceiptCredit_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            PaymentCredit paymentCredit = ((FrameworkElement)sender).DataContext as PaymentCredit;
            if (paymentCredit == null) return;
            Console.WriteLine(paymentCredit.Id + " " + paymentCredit.AccountName);
        }

        private void DG_ReceiptDebit_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            PaymentCredit paymentCredit = ((FrameworkElement)sender).DataContext as PaymentCredit;
            if (paymentCredit == null) return;
            Console.WriteLine(paymentCredit.Id + " " + paymentCredit.AccountName);
        }

        private void DG_ReceiptTax_Click(object sender, RoutedEventArgs e)
        {
            //Hyperlink link = (Hyperlink) e.OriginalSource;
            PaymentCredit paymentCredit = ((FrameworkElement)sender).DataContext as PaymentCredit;
            if (paymentCredit == null) return;
            Console.WriteLine(paymentCredit.Id + " " + paymentCredit.AccountName);
        }

    }

    public class PaymentCredit
    {
        private static int _autoId = 1;
        public PaymentCredit()
        {
            this.Action = "REMOVE";
            this.Id = _autoId++;
        }
        public int Id { get; set; }
        public String AccountName { get; set; }
        public String Action { get; set; }
    }
}

