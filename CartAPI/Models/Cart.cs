using System.Collections.Generic;

namespace CartAPI.Models
{
    public class Cart
    {
        public string BuyerId { get; set; }
        public List<CartItem> items { get; set; }

        public Cart(string cartId, List<CartItem> items)
        {
            BuyerId = cartId;
            items = new List<CartItem>();
        }
    }
}
