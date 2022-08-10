using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebMVC.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public System.DateTime EventDate { get; set; }
        public string Organizer { get; set; }
        public string Address { get; set; }
        public int EventCatagoryId { get; set; }
        public int EventLocationId { get; set; }

        public string  EventCatagory { get; set; }
        public string  EventLocation { get; set; }
    }
}
