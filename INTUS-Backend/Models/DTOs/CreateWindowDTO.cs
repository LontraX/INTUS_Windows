using System.ComponentModel.DataAnnotations;

namespace INTUS_Backend.Models.DTOs
{
    public class CreateWindowDTO
    {
        //[Required]
        public string? Name { get; set; }
        //[Required]
        public int QuantityOfWindows { get; set; }

        public int TotalSubElements { get; set; }

        //public List<CreateSubElementDTO>? SubElements { get; set; }

        //public CreateWindowDTO()
        //{
        //    SubElements = new List<CreateSubElementDTO>();
        //}
    }
}
