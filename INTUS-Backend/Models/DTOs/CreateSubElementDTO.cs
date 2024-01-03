using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS_Backend.Models.DTOs
{
    public class CreateSubElementDTO
    {
        

        [Required]
        [XmlAttribute("Type")]
        public string? Type { get; set; }

        [Required]
        [XmlAttribute("Width")]
        public int Width { get; set; }

        [XmlAttribute("Height")]
        public int Height { get; set; }
    }
}
