using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IOrderDao
    {
        IEnumerable<Order> GetAll();
        bool Create(Order order);
        bool Update(Order order);
    }
}
