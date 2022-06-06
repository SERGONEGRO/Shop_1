using Microsoft.AspNetCore.Mvc;
using Shop_1.Data.Interfaces;

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
            var products = _allProducts.Products;
            return View(products);
        }
    }
}
