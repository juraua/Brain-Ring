using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Brain_Ring.Converters
{
    public class RowToIndexConverter : MarkupExtension, IValueConverter
    {
        static RowToIndexConverter _converter;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DataGridRow row = value as DataGridRow;

            if (row != null)
            {
                return row.GetIndex() + 1;
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_converter == null)
            {
                _converter = new RowToIndexConverter();
            }

            return _converter;
        }


        public RowToIndexConverter()
        {

        }
    }
}
