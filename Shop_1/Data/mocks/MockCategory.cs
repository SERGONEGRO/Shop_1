using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Data.mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Мёд", CategoryDesc = "Натуральные сорта отборного продукта"},
                    new Category {CategoryName = "Продукты пчеловодства", CategoryDesc = "Перга, воск, пыльца и др."}
                };
            }
        }
    }
}
