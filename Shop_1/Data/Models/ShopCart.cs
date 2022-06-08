namespace Shop_1.Data.Models
{
    /// <summary>
    /// Класс, отвечающий за всю корзину
    /// </summary>
    public class ShopCart
    {
        public string ShopCartId { get;set;}
        public List<ShopCartItem> ListShopItems { get;set;}
    }
}
