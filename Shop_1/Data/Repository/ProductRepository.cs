using Microsoft.EntityFrameworkCore;
using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;


namespace Shop_1.Data.Repository
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    public class ProductRepository : IAllProducts
    {
        //переменная для работы с файлос AppDBContent
        private readonly AppDBContent appDBContent;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public ProductRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        /// <summary>
        /// Берем все данные по нужной категории
        /// </summary>
        public IEnumerable<Product> Products => appDBContent.Product.Include(c => c.Category);

        /// <summary>
        /// Выбор только тех записей ,у которых IsFavourite=true
        /// </summary>
        public IEnumerable<Product> GetFavProduct => appDBContent.Product.Where(p => p.IsFavourite).Include(c => c.Category);

        /// <summary>
        /// Выбираем объект по id
        /// </summary>
        /// <param name="productId">current id</param>
        /// <returns>нужный нам product</returns>
        public Product GetObjectProduct(int productId) => appDBContent.Product.FirstOrDefault(p => p.Id == productId);
      
    }
}
