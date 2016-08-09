using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WebShopWinApp.ValidationCheck
{
   public class AvailabilityCheck : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {

            int val = (int)value;

            if (val >= 5)
            {

                return "Assets/Ilagar.png";

            }
            else if (val < 5 && val > 0)
            {
                return "Assets/Lt5ilagar.png";
            }
            else
                return "Assets/Slut.png";


        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string visibility = value as string;

            if (visibility == "Assets/Ilagar.png")
            {
                return 5;
            }

            else if (visibility == "Assets/LT5ilagar.png")
            {
                return 4;
            }

            else
                return 0;

        }
    }
}
