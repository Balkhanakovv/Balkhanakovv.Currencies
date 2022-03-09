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

        public List<double> GetWeekRange(string currId)
        {
            StringBuilder requestUrl = new StringBuilder("http://www.cbr.ru/scripts/XML_daily.asp");
            requestUrl.Append($"?date_req1={DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            requestUrl.Append($"&date_req2={DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}");
            requestUrl.Append($"&VAL_NM_RQ={"R0101"}");

            return null;
        }
    }
}
