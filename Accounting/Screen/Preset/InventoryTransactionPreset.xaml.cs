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
using Accounting.Model;
using Accounting.Screen.Page;

namespace Accounting.Screen.Preset
{
    /// <summary>
    /// Interaction logic for InventoryTransactionPreset.xaml
    /// </summary>
    public partial class InventoryTransactionPreset : UserControl
    {
        private readonly AdvanceMenu _parent;

        public InventoryTransactionPreset(AdvanceMenu parent)
        {
            _parent = parent;
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var viewSourceTax = (System.Windows.Data.CollectionViewSource)this.Resources["ViewSourceTax"];
            viewSourceTax.Source = DataModel.Instance.GetTax();
            
            var viewSourceCredit = (System.Windows.Data.CollectionViewSource)this.Resources["ViewSourceDebit"];
            viewSourceCredit.Source = DataModel.Instance.GetDebitAccounts();

            var viewSourceDebit = (System.Windows.Data.CollectionViewSource)this.Resources["ViewSourceCredit"];
            viewSourceDebit.Source = DataModel.Instance.GetCreditAccounts();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _parent.Reload();
        }
    }
}
