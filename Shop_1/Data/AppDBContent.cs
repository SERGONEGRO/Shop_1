using Microsoft.EntityFrameworkCore;
using Shop_1.Data.Models;

namespace Shop_1.Data
{
    /// <summary>
    /// For work with DB
    /// </summary>
    public class AppDBContent : DbContext
    {
        /// <summary>
        /// Конструктор по умолчанию. Получает данные и передает в базовый конструктор
        /// </summary>
        /// <param name="options"></param>
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options){

        }

        /// <summary>
        /// Получает все товары в магазине
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Получает все категории
        /// </summary>
        public DbSet<Category> Category { get; set; }

        /// <summary>
        /// Получает все элементы корзины
        /// </summary>
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
    }
   
}
