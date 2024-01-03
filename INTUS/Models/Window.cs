using System.ComponentModel.DataAnnotations;

namespace INTUS.Models
{
    public class Window
    {
        
        public string? WindowId { get; set; } = Guid.NewGuid().ToString();

        
        public string? Name { get; set; }
        
        public int QuantityOfWindows { get; set; }

        public List<SubElement>? SubElements { get; set; }

        public int TotalSubElements { get; set; }

        //public Order? Order { get; set; }
        public Window()
        {
            SubElements = new List<SubElement>();
        }
    }
}
