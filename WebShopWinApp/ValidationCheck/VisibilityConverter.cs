using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WebShopWinApp.ValidationCheck
{
    public class VisibilityConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, string language)
        {

            int val = (int)value;

            if (val == 0)
            {

                return "Collapsed";

            }
            
            else
                return "Visible";


        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string visibility = value as string;

            if (visibility == "Visible")
            {
                return 5;
            }

            

            else
                return 0;

        }



    }
}
