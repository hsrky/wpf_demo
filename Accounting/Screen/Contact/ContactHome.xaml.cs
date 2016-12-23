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
    /// Interaction logic for ContactHome.xaml
    /// </summary>
    public partial class ContactHome : UserControl
    {
        public ContactHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeContent.Open(new CreateContact());
        }
    }
}
