using System.ComponentModel.DataAnnotations;

namespace INTUS_Backend.Models.DTOs
{
    public class UpdateWindowDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        //public List<CreateSubElementDTO>? SubElements { get; set; }

        //public UpdateWindowDTO()
        //{
        //    SubElements = new List<CreateSubElementDTO>();
        //}
    }
}
