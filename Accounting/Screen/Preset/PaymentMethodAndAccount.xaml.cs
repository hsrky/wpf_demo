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

namespace Accounting.Screen.Preset
{
    /// <summary>
    /// Interaction logic for PaymentMethodAndAccount.xaml
    /// </summary>
    public partial class PaymentMethodAndAccount : UserControl
    {
        private readonly AdvanceMenu _parent;
        public PaymentMethodAndAccount(AdvanceMenu parent)
        {
            _parent = parent;
            InitializeComponent();
        }
    }
}
