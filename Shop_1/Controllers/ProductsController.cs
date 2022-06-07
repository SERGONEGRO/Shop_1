using Microsoft.AspNetCore.Mvc;
using Shop_1.Data.Interfaces;
using Shop_1.ViewModels;

namespace Shop_1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductsCategory _allCategories;


        //поскольку в файле startup мы связали интерфейсы с классами, кторые их реализуют,
        //то теперь через них могут передаваться данные классов
        public ProductsController(IAllProducts iAllProducts,IProductsCategory iProductsCat)
        {
            _allProducts = iAllProducts;
            _allCategories = iProductsCat;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с товарами";   //title можно передавать во viewbag
            //создаем и передаем 1 объект вместо нескольких
            ProductsListViewModel obj = new ProductsListViewModel();
            obj.AllProducts = _allProducts.Products;
            obj.currCategory = "Мед свежий из пизды медвежьей";
          
            return View(obj);
        }
    }
}
