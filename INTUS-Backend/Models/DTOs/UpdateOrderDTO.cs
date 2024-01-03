using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS_Backend.Models.DTOs
{
    public class UpdateOrderDTO
    {
        [Required]
        //[XmlAttribute("Name")]
        public string? Name { get; set; }

        [Required]
        //[XmlAttribute("State")]
        public string? State { get; set; }
    }
}
