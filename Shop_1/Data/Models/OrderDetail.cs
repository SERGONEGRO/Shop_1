namespace Shop_1.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        /// <summary>
        /// id заказа
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// id товара, который приобретаем
        /// </summary>
        public int ProductId { get; set; }

        public uint Price { get; set; }

        /// <summary>
        /// продукт, который приобретаем
        /// </summary>
        public virtual Product Product { get; set; }

        /// <summary>
        /// заказ, с которым работаем
        /// </summary>
        public virtual Order Order { get; set; }

    }
}
