using System;
using MicroserviceECommerce.Basket.Entities.Dtos.BasketDtos;

namespace MicroserviceECommerce.Basket.Services.Contracts;

public interface IBasketService
{
    public Task<GetMyBasketDto> GetBasketAsync();
    public Task SaveBasketAsync(SaveBasketDto basketTotalDto);
    public Task DeleteBasketAsync(string userId);
}
