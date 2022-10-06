using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Orderline
    {
        public int Quantity { get; set; }

        public Product Item { get; set; }

        public Orderline(int quantity, Product item)
        {
            Quantity = quantity;
            Item = item;
        }

        public override string ToString()
        {
            return $"{Quantity} cups {Item.Name}, unit price {Item.Price}";
        }
    }
}
