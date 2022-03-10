using Balkhanakovv.Currencies.Models;

namespace Balkhanakovv.Currencies.Services.CurrencyService
{
    public interface ICurrencyService
    {
        public XmlValCurs CurrenciesList { get; set; }

        public void GetCurrencies();

        public void GetWeekRange(string currId);
    }
}
