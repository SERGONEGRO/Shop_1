using Shop_1.Data.Models;

namespace Shop_1.ViewModels
{
    /// <summary>
    /// на основе этой модели создаем объекты и записываем в него нужные значения,
    /// чтобы потом передать во View 1 обьект, а не несколько
    /// </summary>
    public class ProductsListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }

        public string currCategory { get; set; }
    }
}
