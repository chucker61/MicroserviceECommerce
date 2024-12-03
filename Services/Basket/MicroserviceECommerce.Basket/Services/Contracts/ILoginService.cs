using System;

namespace MicroserviceECommerce.Basket.Services.Contracts;

public interface ILoginService
{
    public string GetUserId { get; }
}
