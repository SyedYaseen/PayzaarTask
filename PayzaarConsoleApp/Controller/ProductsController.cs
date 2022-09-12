using PayzaarConsoleApp.Interface;
using PayzaarConsoleApp.Models;

namespace PayzaarConsoleApp.Controller;

public class ProductsController
{
    private readonly IProductRepository _productsRepo;

    public ProductsController(IProductRepository productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public List<Product> GetAllProducts()
    {
        return _productsRepo.ListAllProducts();
    }

    public List<Product> FilterProducts()
    {
        return _productsRepo.GetCurrentAvailableProducts();
    }

    public void UpdateProductsByTime()
    {
        _productsRepo.UpdateListOfAvailableProducts();
    }
    
    public List<Product> DisplayAvailableProducts()
    {
        return _productsRepo.DisplayAvailableProducts();
    }
    
    
    public static void PrintValues(List<Product> products)
    {
        if (!products.Any()) Console.WriteLine("There are no products available at this time of day");
        else
        {
            Console.WriteLine("Products available current time of day:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductType == ProductTypeEnum.AllDay
                    ? product.ProductName
                    : $"{product.ProductName} {product.StartHour}:00-{product.EndHour}:00");
            }
        }
    }
    
    
    
    
    
    
}