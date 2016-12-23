using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accounting.Entity;
using Accounting.Screen.Preset;

namespace Accounting.Screen.Page
{
    /// <summary>
    /// Interaction logic for AdvanceMenu.xaml
    /// </summary>
    public partial class AdvanceMenu : UserControl
    {
        private String _selectedMenu = "";

        public AdvanceMenu()
        {
            InitializeComponent();
            SetLabelAction();
        }

        public void Reload()
        {
            LoadToContent(_selectedMenu);
        }

        private void AdvMenuSelection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach(var label in AdvMenuSelection.Children.OfType<Label>())
            {
                label.Background = label.Name != _selectedMenu ? Const.Color.Default : Const.Color.Selected;
            }
        }

        private void LoadToContent(String controlName)
        {
            UserControl control = null;
            DisplayContentTitle.Visibility = Visibility.Visible;
            switch (controlName)
            {
                case "ChartOfAccountsLabel":
                    control = new ChartOfAccounts(this);
                    break;

                case "AdjustmentLabel":
                    control = new ManualAdjustment();
                    break;

                case "TaxCodeLabel":
                    control = new TaxCodes(this);
                    break;

                case "AccountTypeLabel":
                    control = new AccountType(this);
                    break;

                case "TermLabel":
                    control = new Terms(this);
                    break;

                case "TransactionLabel":
                    DisplayContentTitle.Visibility = Visibility.Collapsed;
                    control = new InventoryTransactionPreset(this);
                    break;

                case "PaymentReceiptLabel":
                    DisplayContentTitle.Visibility = Visibility.Collapsed;
                    control = new PaymentReceiptVisibleAccounts(this);
                    break;

                case "PaymentMethodLabel":
                    DisplayContentTitle.Visibility = Visibility.Collapsed;
                    control = new PaymentMethodAndAccount(this);
                    break;

                case "CurrencyLabel":
                    throw new Exception("Currency Page Not Yet Implemented");

            }

            DisplayContent.Content = control;
        }

        private void SetLabelAction()
        {
            foreach (var label in AdvMenuSelection.Children.OfType<Label>())
            {
                var label1 = label;
                label.MouseDown += (s, ev) =>
                {
                    if (label1.Name == _selectedMenu) return; // same menu selected
                    if (_selectedMenu == "") DisplayContentPanel.Visibility = Visibility.Visible; // first choose

                    _selectedMenu = label1.Name;
                    ContentTitle.Content = label1.Content; // set title
                    LoadToContent(_selectedMenu);
                };

                label.MouseEnter += (s, e) =>
                {
                    var lbl = s as Label;
                    if (lbl == null) return;
                    //if (lbl.Name == _selectedMenu) return;
                    lbl.Background = Const.Color.MouseOver;
                };

                label.MouseLeave += (s, e) =>
                {
                    var lbl = s as Label;
                    if (lbl == null) return;
                    lbl.Background = lbl.Name == _selectedMenu ? Const.Color.Selected : Const.Color.Default;
                };

            }
        }

    }
}
