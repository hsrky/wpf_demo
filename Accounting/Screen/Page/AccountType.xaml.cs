using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

namespace Accounting.Screen.Page
{
    /// <summary>
    /// Interaction logic for AccountType.xaml
    /// </summary>
    public partial class AccountType : UserControl
    {
        private readonly AdvanceMenu _parent;
        private Entities _context = new Entities();
        public AccountType(AdvanceMenu parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _context.account_type.Load();
            var taxCodeSource = (System.Windows.Data.CollectionViewSource)this.Resources["account_typeViewSource"];
            taxCodeSource.Source = _context.account_type.Local;

            _context.ref_account_type.Load();
            var refAccountType = (System.Windows.Data.CollectionViewSource)(this.Resources["refAccountTypeViewSource"]);
            refAccountType.Source = _context.ref_account_type.Local;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Common.verifyControlValid(account_typeDataGrid))
            {
                return;
            }

            if (Common.hasDbValidationErrors(_context.GetValidationErrors()))
            {
                return;
            }
            _context.SaveChanges();
            CancelButton.IsEnabled = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _parent.Reload();
        }

        private void account_typeDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CancelButton.IsEnabled = true;
        }
    }
}
