using Microsoft.AspNetCore.Mvc;
using Shop_1.Data.Interfaces;
using Shop_1.ViewModels;

namespace Shop_1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// список продуктов
        /// </summary>
        private IAllProducts _productRep;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="productRep"></param>
        /// <param name="shopCart"></param>
        public HomeController(IAllProducts productRep)
        {
            _productRep = productRep;
        }

        public ViewResult Index()
        {
            var homeProducts = new HomeViewModel
            {
                FavProducts = _productRep.GetFavProduct
            };
            return View(homeProducts);
        }
    }
}
