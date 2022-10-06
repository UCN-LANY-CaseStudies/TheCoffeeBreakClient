using DataAccess.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaoFactory
    {
        public static IOrderDao CreateOrderDao()
        {
            return new OrderDao();
        }

        public static IProductDao CreateProductDao()
        {
            return new ProductDao();
        }
    }
}
