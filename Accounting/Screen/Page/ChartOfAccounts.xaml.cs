using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Accounting.Entity;
using System.Data.Entity.Validation;

namespace Accounting.Screen.Page
{
    public partial class ChartOfAccounts : UserControl, IDisposable
    {
        private Entities _context = new Entities();
        private readonly AdvanceMenu _parent;
        public ChartOfAccounts(AdvanceMenu parent)
        {
            InitializeComponent();
            _parent = parent;
            //_context.Database.Connection.ConnectionString = Config.Instance.GetConnectionString();
            // read this
            //http://www.codeproject.com/Articles/30905/WPF-DataGrid-Practical-Examples
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //http://msdn.microsoft.com/en-us/data/jj574514.aspx
            _context.chart_of_accounts.OrderBy(c => c.code).Load();
            var chartOfAccountsViewSource = 
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("chart_of_accountsViewSource")));
            chartOfAccountsViewSource.Source = _context.chart_of_accounts.Local;

            _context.tax_code.Load();
            var taxCodeViewSource =
                (System.Windows.Data.CollectionViewSource)(this.FindResource("refTaxCodeViewSource"));
            taxCodeViewSource.Source = _context.tax_code.Local;
            //<CollectionContainer x:Name="TaxColumnCollectionContainer"></CollectionContainer>
            //TaxColumnCollectionContainer.Collection = _context.tax_code.Local;

            _context.account_type.Load();
            var accountTypeViewSource =
                (System.Windows.Data.CollectionViewSource)(this.FindResource("refAccountTypeViewSource"));
            accountTypeViewSource.Source = _context.account_type.Local;
            //taxColumn.ItemsSource = (List<tax_code>)_context.tax_code.OrderBy(t => t.tax_codename).ToList();

        }

        public void Close()
        {
            if (this._context == null) return;
            this._context.Dispose();
            this._context = null;
        }

        public void Dispose()
        {
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //chart_of_accountsDataGrid.UpdateLayout();
            //chart_of_accountsDataGrid.Items.Refresh();
            // Refresh and UpdateLayout don't work... so ask parent to reload this control...
            _parent.Reload();
        }

        private void chart_of_accountsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CancelButton.IsEnabled = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Common.verifyControlValid(chart_of_accountsDataGrid))
            {
                return;
            }

            if (Common.hasDbValidationErrors(_context.GetValidationErrors()))
            {
                return;
            }
            _context.SaveChanges();
            CancelButton.IsEnabled = false;
            chart_of_accountsDataGrid.Items.Refresh();
        }

        private void RemoveAll()
        {
            foreach (var row in _context.chart_of_accounts.Local.ToList())
            {// remove data...danger...
                _context.chart_of_accounts.Remove(row);
            }
        }
    }
}
