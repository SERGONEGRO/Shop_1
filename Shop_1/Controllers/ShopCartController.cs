using Microsoft.AspNetCore.Mvc;
using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;
using Shop_1.ViewModels;

namespace Shop_1.Controllers
{
    public class ShopCartController : Controller
    {
        /// <summary>
        /// список продуктов
        /// </summary>
        private IAllProducts _productRep;
        /// <summary>
        /// текущая корзина
        /// </summary>
        private readonly ShopCart _shopCart;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="productRep"></param>
        /// <param name="shopCart"></param>
        public ShopCartController(IAllProducts productRep, ShopCart shopCart)
        {
            _productRep = productRep;
            _shopCart = shopCart;
        }

        /// <summary>
        /// возвращает шаблон View с объектом - корзиной
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            //устанавливаем список товаров в корзину
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            { 
                ShopCart = _shopCart
            };

            return View(obj);
        }

        /// <summary>
        /// Добавляет товар в корзину
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns></returns>
        public RedirectToActionResult AddToCart(int id)
        {
            //выбираем товар с нужным id
            var item = _productRep.Products.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            //переадресовываем на страницу с корзиной
            return RedirectToAction("Index");
        }
    }
}
