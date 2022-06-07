using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Data.mocks
{
    /// <summary>
    /// Класс, реализующий интерфейс
    /// </summary>
    public class MockProducts : IAllProducts
    {
        private readonly IProductsCategory _categoryProducts = new MockCategory();
        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product {
                        Name = "Мед липовый",
                        ShortDesc = "Классический вкус",
                        LongDesc = "Очень полезный и вкусный мед ",
                        Img = "https://images.unsplash.com/photo-1587049352851-8d4e89133924",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.First()
                    },
                    new Product {
                        Name = "Мед разнотравье",
                        ShortDesc = "Ароматная симфония",
                        LongDesc = "Ощути весь букет летних ароматов с нашим медом, собранным в альпийских лугах",
                        Img = "https://images.unsplash.com/photo-1587049352851-8d4e89133924",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.First()
                    },
                    new Product {
                        Name = "Перга",
                        ShortDesc = "Покупай пока не сгнила",
                        LongDesc = "Спрессованная пчелами пыльца, богата белком",
                        Img = "https://images.unsplash.com/photo-1626285094816-39f688104ce0",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.Last()
                    },
                    new Product {
                        Name = "Воск",
                        ShortDesc = "Древнейший продукт",
                        LongDesc = "Можете использовать на своем свечном заводике",
                        Img = "https://images.unsplash.com/photo-1626285094816-39f688104ce0",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.Last()
                    },
                };
            }
        
        }
        public IEnumerable<Product> GetFavProduct { get ; set; }

        public Product GetObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
    