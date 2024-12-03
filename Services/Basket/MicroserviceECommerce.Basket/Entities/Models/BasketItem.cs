using System;

namespace MicroserviceECommerce.Basket.Entities.Models;

public class BasketItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
