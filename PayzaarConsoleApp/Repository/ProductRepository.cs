using PayzaarConsoleApp.Interface;
using PayzaarConsoleApp.Models;

namespace PayzaarConsoleApp.Repository;

public class ProductRepository: IProductRepository
{

    public List<Product> AllProducts = new List<Product>
    {
        new Product { ProductName = "Orange Juice", ProductType = ProductTypeEnum.AllDay },
        new Product { ProductName = "Breakfast Burrito", ProductType = ProductTypeEnum.Limited, StartHour = 8, EndHour = 12 },
        new Product { ProductName = "Steak & Chips", ProductType =  ProductTypeEnum.Limited, StartHour = 12, EndHour = 21 },
        new Product { ProductName = "Chicken Sandwich", ProductType =  ProductTypeEnum.Limited, StartHour = 11, EndHour = 19 },
        new Product { ProductName = "Sam Adams Seasonal", ProductType =  ProductTypeEnum.Limited, StartHour = 17, EndHour = 23 }
    };
    
    public ProductRepository()
    {
        //I would have added dependency injection
        //to the context class here
    }

    public List<Product> ListAllProducts()
    {
        return AllProducts;
    }

    public void UpdateListOfAvailableProducts()
    {
        //Added additional column/ property in model for availability
        //Easier to update value if this code is set to run periodically.
        //I assumed that was the scenario

        if (AllProducts?.Count != null)
        {
            foreach (var product in AllProducts)
            {
                if (product.ProductType == ProductTypeEnum.AllDay ||
                    (product.StartHour <= DateTime.Now.Hour &&
                     product.EndHour >= DateTime.Now.Hour))
                {
                    product.IsAvailable = true;
                }
            }
        }
    }
    
    public List<Product> DisplayAvailableProducts()
    {
        var availableItems = AllProducts?.Where(p => p.IsAvailable == true).ToList();

        if (!availableItems.Any()) return null;

        else return availableItems;
    }
    
    public List<Product> GetCurrentAvailableProducts()
    {
        if (AllProducts != null)
        {
            return AllProducts.Where(product => product.ProductType == ProductTypeEnum.AllDay ||
                                                (product.StartHour <= DateTime.Now.Hour &&
                                                 product.EndHour >= DateTime.Now.Hour)).ToList<Product>();
        }

        return null;
    }
    
    
}