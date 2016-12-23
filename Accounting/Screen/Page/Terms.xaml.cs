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
using System.Data.Entity.Validation;

namespace Accounting.Screen.Page
{
    /// <summary>
    /// Interaction logic for Terms.xaml
    /// </summary>
    public partial class Terms : UserControl
    {
        private readonly AdvanceMenu _parent;
        private Entities _context = new Entities();
        public Terms(AdvanceMenu parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            _context.terms.Load();
            var taxCodeSource = (System.Windows.Data.CollectionViewSource)this.Resources["termViewSource"];
            taxCodeSource.Source = _context.terms.Local;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Common.verifyControlValid(termDataGrid))
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

        private void termDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CancelButton.IsEnabled = true;
        }
    }
}
