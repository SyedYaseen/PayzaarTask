// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using PayzaarConsoleApp.Controller;
using PayzaarConsoleApp.Models;
using PayzaarConsoleApp.Repository;


class Program
{
    static void Main()
    {
        //If this was inside a controller,
        //repo would be injected as a dependency
        var productsController = new ProductsController(new ProductRepository());
        
        try
        {
            //Implementation 1: With updateByTime method and a
            //display method that retrieves values
            productsController.UpdateProductsByTime();
            var products = productsController.DisplayAvailableProducts();
            
            //Implementation 2: A filter method that eliminates need for an
            //update method and retrieves values on request
            var productsFiltered = productsController.FilterProducts();
            
            //PrintingValues
            ProductsController.PrintValues(products);
            Console.WriteLine("-----------------");
            ProductsController.PrintValues(productsFiltered);
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        Console.ReadKey();
    }
}