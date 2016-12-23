using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Accounting.Entity;

namespace Accounting.Screen.Transaction
{
    /// <summary>
    /// Interaction logic for TransactionForm.xaml
    /// </summary>
    public partial class TransactionForm : UserControl
    {
        private readonly Entities _context = new Entities();

        public TransactionForm()
        {
            InitializeComponent();
            
            var viewSourceTax = (System.Windows.Data.CollectionViewSource)this.Resources["ViewSourceTax"];
            _context.tax_code.Load();
            viewSourceTax.Source = _context.tax_code.Local;

            var viewSourceChartsOfAccount = (System.Windows.Data.CollectionViewSource)this.Resources["ViewSourceChartsOfAccount"];
            _context.chart_of_accounts.Load();
            viewSourceChartsOfAccount.Source = _context.chart_of_accounts.Local;
        }

        private void TxAccCredit1_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = 0.0d;
            try
            {
                value = Convert.ToDouble(TxAccCredit1.Text);
            }
            catch (Exception)
            {
            }

            TxLabelTotal.Content = String.Format("RM {0}", value.ToString("N2"));
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //TxAccCredit1,TxAccDebit2,TxTaxDebit
            var totalCredit = 0.0d;
            var totalDebit = 0.0d;
            try
            {

                totalCredit += Convert.ToDouble(TxAccCredit1.Text == "" ? "0" : TxAccCredit1.Text);
                totalDebit += Convert.ToDouble(TxAccDebit2.Text == "" ? "0" : TxAccDebit2.Text) + Convert.ToDouble(TxTaxDebit.Text == "" ? "0" : TxTaxDebit.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error - Field(s) are not number: " + exp);
                return;
            }

            if (TxAccCredit1.Text == "" && TxAccDebit2.Text == "" && TxTaxDebit.Text == "")
            {
                MessageBox.Show("Error - no value entered");
                return;
            }

            if (Math.Abs(totalCredit - totalDebit) > 0.0001d)
            {
                MessageBox.Show(String.Format("Error - Debit and Credit not balance: RM {0} vs RM {1}", totalDebit.ToString("N4"), totalCredit.ToString("N4")));
                return;
            }

            MessageBox.Show("Input Okay!");

        }
    }
}
