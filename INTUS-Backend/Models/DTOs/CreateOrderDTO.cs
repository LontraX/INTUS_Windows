using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace INTUS_Backend.Models.DTOs
{
    public class CreateOrderDTO
    {
        [Required]
        //[XmlAttribute("Name")]
        public string? Name { get; set; }

        [Required]
        //[XmlAttribute("State")]
        public string? State { get; set; }

        //public List<CreateWindowDTO>? Windows { get; set; }

        //public CreateOrderDTO()
        //{
        //    Windows = new List<CreateWindowDTO>();
        //}

        public Order ToOrder()
        {
            var orderToReturn = new Order()
            {
                Name = this.Name,
                State = this.State
            };

            //if (this.Windows != null)
            //{
            //    var windowList = new List<Window>();

            //    foreach (var windowDto in this.Windows)
            //    {
            //        var window = new Window
            //        {
            //            Name = windowDto.Name,
            //            QuantityOfWindows = windowDto.QuantityOfWindows,
            //            TotalSubElements = windowDto.TotalSubElements,
            //            //Order = orderToReturn
            //        };

            //        if (windowDto.SubElements != null)
            //        {
            //            var subElementList = new List<SubElement>();

            //            foreach (var subElementDto in windowDto.SubElements)
            //            {
            //                subElementList.Add(new SubElement
            //                {
            //                    // Map properties from subElementDto to SubElement entity
            //                    Element = subElementDto.Element,
            //                    Type = subElementDto.Type,
            //                    Width = subElementDto.Width,
            //                    Height = subElementDto.Height,
            //                    // Other properties...
            //                    //Window = window
            //                });
            //            }

            //            window.SubElements = subElementList;
            //        }

            //        windowList.Add(window);
            //    }

            //    orderToReturn.Windows = windowList;
            //}

            return orderToReturn;
        }
    }
}
