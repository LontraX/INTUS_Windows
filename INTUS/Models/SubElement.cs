using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS.Models
{
    public class SubElement
    {
        
        public string? SubElementId { get; set; } = Guid.NewGuid().ToString();

       
        [XmlAttribute("Element")]
        public int Element { get; set; }


        [XmlAttribute("Type")]
        public string? Type { get; set; }

        [XmlAttribute("Width")]
        public int Width { get; set; }

        [XmlAttribute("Height")]
        public int Height { get; set; }
    }
}
