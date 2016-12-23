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

namespace Accounting.Screen.Contact
{
    /// <summary>
    /// Interaction logic for CreateContact.xaml
    /// </summary>
    public partial class CreateContact : UserControl
    {
        public CreateContact()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            HomeContent.Open(new ContactHome());
        }
    }
}
