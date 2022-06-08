using Shop_1.Data.Models;

namespace Shop_1.Data.Interfaces
{
    /// <summary>
    /// Get all about products
    /// </summary>
    public interface IAllProducts
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetFavProduct { get; }
        Product GetObjectProduct(int productId);
    }
}
