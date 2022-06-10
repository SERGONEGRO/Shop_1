using Microsoft.AspNetCore.Mvc;
using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;
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

        [Route("Products/List")]
        [Route("Products/List/{category}")]
        
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string currCategory = "";
            //если строка с параметром категории пустая, то выводим все продукты
            if (string.IsNullOrEmpty(category))
            {
                products = _allProducts.Products.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("honey", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _allProducts.Products.Where(i => i.Category.CategoryName == "Мёд").OrderBy(i => i.Id);
                    currCategory = "Мёд";
                }
                else
                {
                    if (string.Equals("other", category, StringComparison.OrdinalIgnoreCase))
                    {
                        products = _allProducts.Products.Where(i => i.Category.CategoryName == "Продукты пчеловодства").OrderBy(i => i.Id);
                        currCategory = "Продукты пчеловодства";
                    }
                }
            }

            var productObject = new ProductsListViewModel
            {
                AllProducts = products,
                currCategory = currCategory
            };

            ViewBag.Title = "Страница с товарами";   //title можно передавать во viewbag

            return View(productObject);
        }
        
    }
}
