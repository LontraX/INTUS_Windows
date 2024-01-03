using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS_Backend.Models.DTOs
{
    public class UpdateSubElementDTO
    {
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
    }
}
