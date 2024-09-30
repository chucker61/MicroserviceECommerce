using MicroserviceECommerce.Application.Extensions;
using MicroserviceECommerce.Application.Interfaces;
using MicroserviceECommerce.Order.WebApi.Extensions;
using MicroserviceECommerce.Persistance.Repositories;
using MicroserviceECommerce.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices()
    .ConfigurePipeline();

app.Run();
