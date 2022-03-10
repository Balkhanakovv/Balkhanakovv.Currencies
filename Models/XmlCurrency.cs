using System.Xml.Serialization;

namespace Balkhanakovv.Currencies.Models
{
    /// <summary>
    /// Модель, используемая с целью передачи данных из XML-файла ЦБ в объект справочника Валюта
    /// </summary>
    [XmlRoot(ElementName = "Currency")]
    public class Currency
    {

        /// <summary>
        /// Свойство для получения цифрового кода ISO валюты из ЦБ
        /// </summary>
        [XmlElement(ElementName = "NumCode")]
        public string NumCode { get; set; }

        /// <summary>
        /// Свойство для получения алфавитного кода ISO валюты из ЦБ
        /// </summary>
        [XmlElement(ElementName = "CharCode")]
        public string CharCode { get; set; }

        /// <summary>
        /// Свойство для получения номинала валюты из ЦБ
        /// </summary>
        [XmlElement(ElementName = "Nominal")]
        public string Nominal { get; set; }

        /// <summary>
        /// Свойство для получения названия валюты из ЦБ
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Свойство для получения значения валюты из ЦБ
        /// </summary>
        [XmlElement(ElementName = "Value")]
        public string Value { get; set; }

        /// <summary>
        /// Свойство для получения идентификатора валюты из ЦБ
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }

        public XmlValCursDyn? Records { get; set; }
    }

    /// <summary>
    /// Модель, используемая с целью передачи данных из XML-файла ЦБ в объект справочника Курс валюты
    /// </summary>
    [XmlRoot(ElementName = "ValCurs")]
    public class XmlValCurs
    {

        /// <summary>
        /// Свойство для получения данных из XML-файла ЦБ
        /// </summary>
        [XmlElement(ElementName = "Valute")]
        public List<Currency> Currency { get; set; }

        /// <summary>
        /// Свойство для получения даты актуального курса валюты из XML-файла ЦБ
        /// </summary>
        [XmlAttribute(AttributeName = "Date")]
        public string Date { get; set; }
    }
}
