using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Pract_pr_22.Classes
{
    public class NumberToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var bc = new BrushConverter();
            if (value == DBNull.Value)
            {
                return (Brush)bc.ConvertFrom("#000000");
            }
            var input = System.Convert.ToInt16(value);
            
            switch (input)
            {
                case 0:
                    return (Brush)bc.ConvertFrom("#000000");
                case 1:
                    return (Brush)bc.ConvertFrom("#007CC2");
                case 2:
                    return (Brush)bc.ConvertFrom("#007CC2");
                default:
                    return (Brush)bc.ConvertFrom("#000000");
            }
            //if (targetType.Name == "Ruble2")
            //{
               
            //}
            //else
            //{
            //    switch (input)
            //    {
            //        case "0":
            //            return blackColorBrush;
            //        case "1":
            //            return blackColorBrush;
            //        case "2":
            //            return blueColorBrush;
            //        default:
            //            return blackColorBrush;
            //    }
            //}
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
