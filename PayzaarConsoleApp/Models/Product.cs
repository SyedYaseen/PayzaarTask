namespace PayzaarConsoleApp.Models;

public class Product
{
    //Added additional column for availability
    public string ProductName;
    public ProductTypeEnum ProductType;
    public bool IsAvailable;
    public int StartHour, EndHour;
}


public enum ProductTypeEnum {
    AllDay,
    Limited
}