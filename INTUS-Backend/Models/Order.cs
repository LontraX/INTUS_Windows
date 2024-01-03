using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS_Backend.Models
{
    public class Order
    {
        [Key]
        public string? OrderId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [XmlAttribute("Name")]
        public string? Name { get; set; }
        [Required]
        [XmlAttribute("State")]
        public string? State { get; set; }

        public List<Window>? Windows { get; set; }

        public Order()
        {
            Windows = new List<Window>();
        }

    }



}
