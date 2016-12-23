﻿using System;
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
using System.Data.Entity.Validation;

namespace Accounting.Screen.Page
{
    /// <summary>
    /// Interaction logic for TaxCodes.xaml
    /// </summary>
    public partial class TaxCodes : UserControl
    {
        private readonly AdvanceMenu _parent;
        private Entities _context = new Entities();
        public TaxCodes(AdvanceMenu parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _context.tax_code.Load();
            var taxCodeSource = (System.Windows.Data.CollectionViewSource)this.Resources["tax_codeViewSource"];
            taxCodeSource.Source = _context.tax_code.Local;

            _context.chart_of_accounts.Load();
            var chartSource = (System.Windows.Data.CollectionViewSource)this.Resources["refChartOfAccounts"];
            chartSource.Source = _context.chart_of_accounts.Local;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Common.verifyControlValid(tax_codeDataGrid))
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

        private void tax_codeDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
            CancelButton.IsEnabled = true;
        }

    }
}
