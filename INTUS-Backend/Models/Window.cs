using System.ComponentModel.DataAnnotations;

namespace INTUS_Backend.Models
{
    public class Window
    {
        [Key]
        public string? WindowId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string? Name { get; set; }
        [Required]
        public int QuantityOfWindows { get; set; }

        public List<SubElement>? SubElements { get; set; }

        public int TotalSubElements { get; set; }

        //public Order? Order { get; set; }
        public Window()
        {
            SubElements= new List<SubElement>();
        }
    }
}
