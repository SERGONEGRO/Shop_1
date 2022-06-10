using Shop_1.Data.Models;

namespace Shop_1.Data.Interfaces
{
    /// <summary>
    /// Get all orders
    /// </summary>
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
