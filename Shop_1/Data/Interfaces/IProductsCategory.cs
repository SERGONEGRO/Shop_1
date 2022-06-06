using Shop_1.Data.Models;

namespace Shop_1.Data.Interfaces
{
    /// <summary>
    /// Get all categories
    /// </summary>
    public interface IProductsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
