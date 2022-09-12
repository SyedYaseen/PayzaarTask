using PayzaarConsoleApp.Controller;
using PayzaarConsoleApp.Repository;

namespace PayzaarConsoleApp.Tests;

public class ProductControllerTest
{
    [Fact]
    public void Filter_ProductsByTime()
    {
        //Arrange
        var repo = new ProductRepository();
        var ProductsController = new ProductsController(repo);

        //Act
        ProductsController.UpdateProductsByTime();
        
        //Assert
        Assert.NotNull(ProductsController.DisplayAvailableProducts());
        
    }
}