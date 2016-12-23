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

namespace Accounting.Screen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();
            HomeContent.Content = this;
            TopContent.Content = new TopMenuBar();
            LeftContent.Content = new LeftPanel();
        }

        public void LoadContent(UserControl userControl)
        {
            DisplayContent.Content = userControl;
        }

        public void ClearContent()
        {
            DisplayContent.Content = null;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var configScreen = new ChartOfAccounts();
        //    this.Hide();
        //    configScreen.Show();
        //    configScreen.Closed += (s, ev) => this.Show();
        //}
    }
}
