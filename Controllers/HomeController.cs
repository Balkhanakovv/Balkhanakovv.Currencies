using Microsoft.AspNetCore.Mvc;
using Balkhanakovv.Currencies.Models;
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
    }
}