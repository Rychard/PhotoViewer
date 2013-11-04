using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PhotoViewer.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        private bool _isReversed;

        public BooleanToVisibilityConverter()
        {
        }

        public bool IsReversed
        {
            get { return this._isReversed; }
            set { this._isReversed = value; }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToBoolean(value, CultureInfo.InvariantCulture);
            if (this.IsReversed)
            {
                val = !val;
            }
            if (val)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility))
            {
                return DependencyProperty.UnsetValue;
            }
            var visibility = (Visibility)value;
            var result = visibility == Visibility.Visible;
            if (this.IsReversed)
            {
                result = !result;
            }
            return result;
        }
    }
}

