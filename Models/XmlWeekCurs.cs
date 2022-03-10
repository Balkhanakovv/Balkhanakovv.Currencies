using System.Xml.Serialization;

namespace Balkhanakovv.Currencies.Models
{
    public class Record
    {
        public string Nominal { get; set; }

        public string Value { get; set; }

        [XmlAttribute(AttributeName = "Date")]
        public string Date { get; set; }
    }

    [XmlRoot(ElementName = "ValCurs")]
    public class XmlValCursDyn
    {
        [XmlElement(ElementName = "Record")]
        public List<Record> Records { get; set; }
    }
}
