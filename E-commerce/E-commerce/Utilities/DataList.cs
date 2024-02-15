using System.Collections.Generic;
using System.Xml.Serialization;

namespace E_commerce.Utilities
{

    [XmlRoot(ElementName = "DataList")]
    public class DataList
    {
        [XmlElement(ElementName = "Website")]
        public List<Website> website { get; set; } = new List<Website>();
    }
        
    [XmlRoot(ElementName = "Website")]
    public class Website
    {
        [XmlElement(ElementName = "Browser")]
        public string browser { get; set; }

        [XmlElement(ElementName = "BaseUrl")]
        public string url { get; set; }

        [XmlElement(ElementName = "User")]
        public string user { get; set; }

        [XmlElement(ElementName = "Pass")]
        public string pass { get; set; }
    }
    
}
