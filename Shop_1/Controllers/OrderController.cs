using Microsoft.AspNetCore.Mvc;
using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// все заказы
        /// </summary>
        private readonly IAllOrders allOrders;

        private readonly ShopCart shopCart;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="appDBContent"></param>
        /// <param name="shopCart"></param>
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        /// <summary>
        /// Функция завершения заказа
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();
            if(shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("","У вас должны быть товары!");
            }
            if(ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
