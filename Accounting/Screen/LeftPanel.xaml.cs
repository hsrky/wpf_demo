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
using Accounting.Screen.Contact;
using Accounting.Screen.Transaction;
using Accounting.Screen.Item;
using Accounting.Screen.Preset;

namespace Accounting.Screen
{
    /// <summary>
    /// Interaction logic for LeftPanel.xaml
    /// </summary>
    public partial class LeftPanel : UserControl
    {
        private string _selectedMenu = "";
        public LeftPanel()
        {
            InitializeComponent();
            SetLabelAction();
        }

        private void SetLabelAction()
        {
            // mouse over, click effects...
            foreach (var label in LeftPanelContainer.Children.OfType<Label>())
            {
                label.MouseDown += (s, ev) =>
                {
                    var lbl = s as Label;
                    if (lbl == null) return;
                    if (lbl.Name == "") return;
                    HighlightSelectedLabel(lbl);
                    LoadClickedPage(lbl.Name);
                    _selectedMenu = lbl.Name;
                };

                label.MouseEnter += (s, ev) =>
                {
                    var lbl = s as Label;
                    if (lbl == null) return;
                    if (lbl.Name == "") return;
                    lbl.Background = Const.Color.MouseOver;
                };

                label.MouseLeave += (s, ev) =>
                {
                    var lbl = s as Label;
                    if (lbl == null) return;
                    if (lbl.Name == "") return;
                    if (lbl.Name == _selectedMenu) return;
                    lbl.Background = Const.Color.Default;
                };

            }
        }

        private void LoadClickedPage(string pageName)
        {
            //if (pageName == _selectedMenu)
            //{// same page
            //    return;
            //}

            switch (pageName)
            {
                case "AdvanceLabel":
                    HomeContent.Open(new AdvanceMenu());
                    break;
                case "ContactLabel":
                    HomeContent.Open(new ContactHome());
                    break;
                case "TransactionLabel":
                    HomeContent.Open(new TransactionForm());
                    break;
                case "ReportLabel":
                    HomeContent.Open(new ReportHome());
                    break;
                case "DashboardLabel":
                    //HomeContent.Open(new CreateItem());
                    //break;
                default:
                    HomeContent.ClearContent();
                    break;
            }

        }

        /**
         * Highlight selected button, and un-highlight others
         * if `checkingButtonName' is null, will use selectedLabel.Name
         */
        private void HighlightSelectedLabel(Control selectedLabel)
        {
            foreach (var aLabel in LeftPanelContainer.Children.OfType<Label>())
            {
                if (aLabel == null) return;
                if (selectedLabel.Name == aLabel.Name)
                {// this selectedLabel is clicked
                    selectedLabel.Background = Const.Color.Selected;
                    continue;
                }
                // clear other buttons
                aLabel.Background = Const.Color.Default;
            }
        }

        private void BtnAdvance_Click(object sender, RoutedEventArgs e)
        {
            //UserControl advanceMenu = new AdvanceMenu();
            //HomeContent.Open(advanceMenu);
        }
    }
}
