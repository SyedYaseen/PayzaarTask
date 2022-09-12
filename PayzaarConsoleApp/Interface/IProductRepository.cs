using PayzaarConsoleApp.Models;

namespace PayzaarConsoleApp.Interface;

public interface IProductRepository
{
    List<Product> ListAllProducts();
    void UpdateListOfAvailableProducts();
    List<Product> DisplayAvailableProducts();
    List<Product> GetCurrentAvailableProducts();
}