using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.Currencies.Services.CurrencyService;

namespace Balkhanakovv.Currencies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyService _currenyService;

        public HomeController(ICurrencyService currencyService)
        {
            _currenyService = currencyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCurrencies()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public string Curr(string charCode)
        {
            var currency = _currenyService?.CurrenciesList?.Currency?.Find(x => x.CharCode == charCode);
            
            if (currency != null)
            {
                return $"Валюта {charCode}";
            }
            else
            {
                return $"Такого {charCode} нет";
            }
        }
    }
}