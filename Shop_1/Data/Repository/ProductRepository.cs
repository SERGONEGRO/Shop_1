using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Data.Repository
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    public class ProductRepository : IAllProducts
    {
        private readonly AppDBContent appDBContent;
        public IEnumerable<Product> Products => throw new NotImplementedException();

        public IEnumerable<Product> GetFavProduct { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Product GetObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
