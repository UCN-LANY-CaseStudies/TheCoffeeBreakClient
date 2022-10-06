using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public const string STATUS_NEW = "New";
        public const string STATUS_ACTIVE = "Active";
        public const string STATUS_FINISHED = "Finished";

        public string CustomerName { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal Discount { get; set; }

        public string Status { get; set; } = STATUS_NEW;

        public IList<Orderline> Orderlines { get; } = new List<Orderline>();

        public Order(string customerName)
        {
            CustomerName = customerName;
        }

        public override string ToString()
        {
            int cups = 0;
            foreach (Orderline orderline in Orderlines)
            {
                cups += orderline.Quantity;
            }
            return $"{CustomerName}: {cups} cups";
        }
    }
}
