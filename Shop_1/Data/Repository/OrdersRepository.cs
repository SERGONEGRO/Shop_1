using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Data.Repository
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    public class OrdersRepository : IAllOrders
    {
        //переменная для взаимодействия с AppDBContent
        private readonly AppDBContent appDBContent;
        //переменная для взаимодействия с shopCart
        private readonly ShopCart shopCart;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="appDBContent"></param>
        /// <param name="shopCart"></param>
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        /// <summary>
        /// создать заказ
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = el.Product.Id,
                    OrderId = order.Id,
                    Price = el.Product.Price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
