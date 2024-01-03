using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS_Backend.Models
{
    public class SubElement
    {
        [Key]
        public string? SubElementId { get; set; } = Guid.NewGuid().ToString();

        //[Required]
        //[XmlAttribute("Element")]
        //public int Element { get; set; }


        [Required]
        [XmlAttribute("Type")]
        public string? Type { get; set; }

        [Required]
        [XmlAttribute("Width")]
        public int Width { get; set; }

        [Required]
        [XmlAttribute("Height")]
        public int Height { get; set; }

        //public Window? Window { get; set; }
    }
}
