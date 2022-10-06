using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Memory
{
    internal class ProductDao : IProductDao
    {
        private static readonly IList<Product> _products = new List<Product>()
        {
            new Product(1, "Coffee", 29.99M),
            new Product(2, "Caffè Latte", 34.99M),
            new Product(3, "Americano", 29.99M),
            new Product(4, "Espresso", 34.99M),
            new Product(5, "Cappuccino", 34.99M)
        };

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
