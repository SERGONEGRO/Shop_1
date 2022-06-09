using Microsoft.EntityFrameworkCore;

namespace Shop_1.Data.Models
{
    /// <summary>
    /// Класс, отвечающий за всю корзину
    /// </summary>
    public class ShopCart
    {
        public string ShopCartId { get;set;}
        public List<ShopCartItem> ListShopItems { get;set;}

        //переменная для работы с файлом AppDBContent
        private readonly AppDBContent appDBContent;

        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        /// <summary>
        /// При первом вызове создает id корзины, при последующих просто возвращает его.
        /// </summary>
        /// <returns></returns>
        public static ShopCart GetCart(IServiceProvider services)
        {
            //создаем объект, при помощи которого сможем работать с сессиями
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //переменная для работы с БД
            var context = services.GetService<AppDBContent>();
            //присваеваем корзине id. если корзина не была создана, то создаем новый id
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //добавляем новое значение CartId в сессию
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        /// <summary>
        /// добавляет в корзину товары
        /// </summary>
        /// <param name="product">продукт</param>
        /// <param name="amount">количество</param>
        public void AddToCart(Product product)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Product = product,
                Price = product.Price
            });

            appDBContent.SaveChanges();
        }

        /// <summary>
        /// возвращает Продукты с id корзины = id корзины в текущей сессии
        /// </summary>
        /// <returns></returns>
        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Product).ToList();
        }
    }
}
