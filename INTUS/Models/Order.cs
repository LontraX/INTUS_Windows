using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS.Models
{
    public class Order
    {
        
        public string? OrderId { get; set; } = Guid.NewGuid().ToString();

        
        [XmlAttribute("Name")]
        public string? Name { get; set; }
       
        [XmlAttribute("State")]
        public string? State { get; set; }

        public List<Window>? Windows { get; set; }

        public Order()
        {
            Windows = new List<Window>();
        }
    }
}
