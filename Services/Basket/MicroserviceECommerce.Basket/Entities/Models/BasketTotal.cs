using System;

namespace MicroserviceECommerce.Basket.Entities.Models;

public class BasketTotal
{
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; }
    public List<BasketItem> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
}
