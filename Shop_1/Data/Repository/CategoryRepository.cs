using Shop_1.Data.Interfaces;
using Shop_1.Data.Models;

namespace Shop_1.Data.Repository
{
    /// <summary>
    /// Класс для работы с БД
    /// </summary>
    public class CategoryRepository : IProductsCategory
    {
        //переменная для работы с файлос AppDBContent
        private readonly AppDBContent appDBContent;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        /// <summary>
        /// Поулчаем все категории
        /// </summary>
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
