namespace Shop_1.Data.Models
{
    /// <summary>
    /// Класс, отвечающий за элемент корзины
    /// </summary>
    public class ShopCartItem
    {
        /// <summary>
        /// id продукта
        /// </summary>
        public int Id { get; set; }
        public Product Product { get; set; }
        public int price { get; set; }

        /// <summary>
        /// Id корзины, к кторой прикреплен итем
        /// </summary>
        public string ShopCartId { get; set; }
    }
}
