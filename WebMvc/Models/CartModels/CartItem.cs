
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.CartModels
{
    public class CartItem
    {
        public  string Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }

        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal OldUnitPrice { get; set; }

        public DateTime EventDate { get; set; }
    }
}
