using System;
using MicroserviceECommerce.Basket.Entities.Models;

namespace MicroserviceECommerce.Basket.Entities.Dtos.BasketDtos;

public class GetMyBasketDto
{
    public int DiscountRate { get; set; }
    public List<BasketItem> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
}
