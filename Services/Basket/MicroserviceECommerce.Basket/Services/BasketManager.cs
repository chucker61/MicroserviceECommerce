using System;
using System.Text.Json;
using MicroserviceECommerce.Basket.Entities.Dtos.BasketDtos;
using MicroserviceECommerce.Basket.Entities.Models;
using MicroserviceECommerce.Basket.Services.Contracts;
using MicroserviceECommerce.Basket.Settings;

namespace MicroserviceECommerce.Basket.Services;

public class BasketManager : IBasketService
{
    private readonly RedisService _redisService;
    private readonly ILoginService _loginService;

    public BasketManager(RedisService redisService, ILoginService loginService)
    {
        _redisService = redisService;
        _loginService = loginService;
    }

    public async Task DeleteBasketAsync(string userId)
    {
        await _redisService.GetDb().KeyDeleteAsync(userId);
    }

    public async Task<GetMyBasketDto> GetBasketAsync()
    {
        var userId = _loginService.GetUserId;
        var basket = await _redisService.GetDb().StringGetAsync(userId);
        return JsonSerializer.Deserialize<GetMyBasketDto>(basket);
    }

    public async Task SaveBasketAsync(SaveBasketDto saveTotalDto)
    {
        var userId = _loginService.GetUserId;
        var basketTotal = new BasketTotal
        {
            UserId = userId,
            DiscountCode = saveTotalDto.DiscountCode,
            DiscountRate = saveTotalDto.DiscountRate,
            BasketItems = saveTotalDto.BasketItems
        };
        await _redisService.GetDb().StringSetAsync(userId, JsonSerializer.Serialize(basketTotal));
    }
}
