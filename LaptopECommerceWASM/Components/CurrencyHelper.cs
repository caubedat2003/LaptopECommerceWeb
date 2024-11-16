using System.Globalization;

namespace LaptopECommerceWASM.Components
{
    public static class CurrencyHelper
    {
        private static readonly string _currencyFormat;

        static CurrencyHelper()
        {
            // Đọc định dạng từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _currencyFormat = configuration["CurrencyFormat"] ?? "#,##0₫";
        }

        public static string FormatCurrency(int price)
        {
            return price.ToString(_currencyFormat, CultureInfo.InvariantCulture);
        }
    }
}
