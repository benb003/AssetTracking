using AssetTracking.Models;

namespace AssetTracking.Services
{
    public class CurrencyConverter
    {
        public static decimal CurrencyConvert(Product product)
        {
            
            if (product.Office.Currency.Equals("Euro"))
            {
                return ((decimal)product.Price) * 1.09M;
            }
            else if (product.Office.Currency.Equals("Pound"))
            {
                return ((decimal)product.Price) * 1.25M;
            }
            else if (product.Office.Currency.Equals("Yen"))
            {
                return ((decimal)product.Price) / 0.006M;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
