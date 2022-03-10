using System.Globalization;
using System.Net;
using System.Text;
using System.Xml.Serialization;

using Balkhanakovv.Currencies.Models;

namespace Balkhanakovv.Currencies.Services.CurrencyService
{
    public class CurrencyService : ICurrencyService
    {
        public XmlValCurs CurrenciesList { get; set; } = null;

        public const string ProviderUrl = "http://www.cbr.ru/scripts/XML_daily.asp";

        public void GetCurrencies()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1254");

            var request = (HttpWebRequest)WebRequest.Create("http://www.cbr.ru/scripts/XML_daily.asp");

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var receiveStream = response.GetResponseStream();
                var serializer = new XmlSerializer(typeof(XmlValCurs));

                if (receiveStream != null)
                {
                    CurrenciesList = (XmlValCurs)serializer.Deserialize(receiveStream);
                }
            }
        }

        public void GetWeekRange(string currId)
        {
            StringBuilder requestUrl = new StringBuilder("http://www.cbr.ru/scripts/XML_daily.asp");
            requestUrl.Append($"?date_req1={DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            requestUrl.Append($"&date_req2={DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            requestUrl.Append($"&VAL_NM_RQ={currId}");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1254");

            var request = (HttpWebRequest)WebRequest.Create(
                $"https://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}&date_req2={DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}&VAL_NM_RQ={currId}"
            );

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var receiveStream = response.GetResponseStream();
                var serializer = new XmlSerializer(typeof(XmlValCursDyn));

                if (receiveStream != null)
                {
                    var result = (XmlValCursDyn)serializer.Deserialize(receiveStream);

                    CurrenciesList.Currency[CurrenciesList.Currency.FindIndex(x => x.ID == currId)].Records = result;
                }
            }
        }
    }
}
