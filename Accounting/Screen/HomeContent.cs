using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Accounting.Screen
{
    // Use to load Main Content in Home Screen
    public static class HomeContent
    {
        // Set to `HomeScreen' instance by its constructor
        public static HomeScreen Content;

        // using manual calling now
        public static void Open(UserControl userControl)
        {
            Content.LoadContent(userControl);
        }

        public static void ClearContent()
        {
            Content.ClearContent();
        }
    }
}
