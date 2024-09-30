using NLog;
using MicroserviceECommerce.Catalog.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureService()
    .ConfigurePipeline();
app.Run();
