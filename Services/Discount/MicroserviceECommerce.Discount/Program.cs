using MicroserviceECommerce.Discount.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureService()
    .ConfigurePipeline();

app.Run();
