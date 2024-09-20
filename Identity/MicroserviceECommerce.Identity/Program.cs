using MicroserviceECommerce.Identity.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => options.LoginPath = "/account/login");

//OpenIddict servisini uygulamaya ekliyoruz.
builder.Services.AddOpenIddict()
    //OpenIddict core/çekirdek yapýlandýrmalarý gerçekleþtiriliyor.
    .AddCore(options =>
    {
        //Entity Framework Core kullanýlacaðý bildiriliyor.
        options.UseEntityFrameworkCore()
               //Kullanýlacak context nesnesi bildiriliyor.
               .UseDbContext<ApplicationDbContext>();
    })
    //OpenIddict server yapýlandýrmalarý gerçekleþtiriliyor.
    .AddServer(options =>
    {
        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

        // Register the signing credentials.
        options.AddDevelopmentSigningCertificate();
        //Token talebinde bulunulacak endpoint'i set ediyoruz.
        options.SetTokenEndpointUris("/connect/token");
        //Akýþ türü olarak Client Credentials Flow'u etkinleþtiriyoruz.
        options.AllowClientCredentialsFlow();
        //Signing ve encryption sertifikalarýný ekliyoruz.
        options.AddEphemeralEncryptionKey()
               .AddEphemeralSigningKey()
               //Normalde OpenIddict üretilecek token'ý güvenlik amacýyla þifreli bir þekilde bizlere sunmaktadýr.
               //Haliyle jwt.io sayfasýnda bu token'ý çözümleyip görmek istediðimizde þifresinden dolayý
               //incelemede bulunamayýz. Bu DisableAccessTokenEncryption özelliði sayesinde üretilen access token'ýn
               //þifrelenmesini iptal ediyoruz.
               .DisableAccessTokenEncryption();
        //OpenIddict Server servislerini IoC Container'a ekliyoruz.
        options.UseAspNetCore()
               //EnableTokenEndpointPassthrough : OpenID Connect request'lerinin OpenIddict tarafýndan iþlenmesi için gerekli konfigürasyonu saðlar.
               .EnableTokenEndpointPassthrough();
        //Yetkileri(scope) belirliyoruz.
        options.RegisterScopes("read", "write");
    });

//OpenIddict'i SQL Server'ý kullanacak þekilde yapýlandýrýyoruz.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //OpenIddict tarafýndan ihtiyaç duyulan Entity sýnýflarýný kaydediyoruz.
    options.UseOpenIddict();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
