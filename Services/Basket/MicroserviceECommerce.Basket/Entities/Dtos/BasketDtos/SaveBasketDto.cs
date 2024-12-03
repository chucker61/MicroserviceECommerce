using System;
using MicroserviceECommerce.Basket.Entities.Models;

namespace MicroserviceECommerce.Basket.Entities.Dtos.BasketDtos;

public class SaveBasketDto
{
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; }
    public List<BasketItem> BasketItems { get; set; }
}
