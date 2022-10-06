using Model;

namespace Controller
{
    public class OrderHandling
    {
        private readonly IList<Order> _orders = new List<Order>();
        private readonly IList<Product> _products = new List<Product>();

        #region Singleton

        private static OrderHandling _instance = new();

        public static OrderHandling Instance
        {
            get
            {
                return _instance;
            }
        }

        private OrderHandling()
        {
            // Loading products
            TextReader productsReader = new StreamReader("products.txt");
            int id = 0;
            while (productsReader.Peek() >= 0)
            {
                string[]? product = productsReader.ReadLine()?.Split(';');
                if (product != null)
                {
                    _products.Add(new Product(++id, product[0], Convert.ToDecimal(product[1])));
                }
            }
        }

        #endregion

        public IEnumerable<Order> GetActiveOrders()
        {
            foreach (var item in _orders)
            {
                if (item.Status == Order.STATUS_ACTIVE)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void CreateOrder(Order order)
        {
            if (!order.Orderlines.Any())
            {
                throw new OrderHandlingException("An order must have orderlines!");
            }
            order.Status = Order.STATUS_ACTIVE;
            _orders.Add(order);
        }

        public void FinishOrder(string customerName)
        {
            Order finishedOrder = _orders.Single(o => o.CustomerName == customerName);
            finishedOrder.Status = Order.STATUS_FINISHED;
        }
    }
}