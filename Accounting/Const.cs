using System.Windows.Media;

namespace Accounting
{
    public struct Const
    {
        public struct Color
        {
            public static readonly SolidColorBrush MouseOver =
                (SolidColorBrush) (new BrushConverter().ConvertFrom("#BEE6FD"));

            public static readonly SolidColorBrush MouseOverContrast =
                (SolidColorBrush)(new BrushConverter().ConvertFrom("#89D1FB"));

            public static readonly SolidColorBrush Selected =
                (SolidColorBrush) (new BrushConverter().ConvertFrom("#BEE6FD"));

            public static readonly SolidColorBrush Default = Brushes.Transparent;

            public static readonly SolidColorBrush Transparent = Brushes.Transparent;
        }
    }
}