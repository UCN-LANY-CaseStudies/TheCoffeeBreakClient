using Model;

namespace DataAccess.Memory
{
    internal class OrderDao : IOrderDao
    {
        private static readonly IList<Order> _orders = new List<Order>();

        public bool Create(Order order)
        {
            if(_orders.Any(o=>o.CustomerName == order.CustomerName))
            {
                return false;
            }
            _orders.Add(order);
            return true;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public bool Update(Order order)
        {
            return true;
        }
    }
}