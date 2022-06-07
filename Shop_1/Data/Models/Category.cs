namespace Shop_1.Data.Models
{
    /// <summary>
    /// Модель категории
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public List<Product> Products { get; set; }

    }
}
