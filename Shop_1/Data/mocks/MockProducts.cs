using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Data.mocks
{
    /// <summary>
    /// Класс для работы без БД, реализующий интерфейс
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
                        Img = "/img/honey-1.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.First()
                    },
                    new Product {
                        Name = "Мед разнотравье",
                        ShortDesc = "Ароматная симфония",
                        LongDesc = "Ощути весь букет летних ароматов с нашим медом, собранным в альпийских лугах",
                        Img = "/img/honey-2.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.First()
                    },
                    new Product {
                        Name = "Перга",
                        ShortDesc = "Покупай пока не сгнила",
                        LongDesc = "Спрессованная пчелами пыльца, богата белком",
                        Img = "/img/perga.jpg",
                        Price = 1000,
                        IsFavourite = true,
                        Available = true,
                        Category = _categoryProducts.AllCategories.Last()
                    },
                    new Product {
                        Name = "Воск",
                        ShortDesc = "Древнейший продукт",
                        LongDesc = "Можете использовать на своем свечном заводике",
                        Img = "/img/vosk.jpg",
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
    