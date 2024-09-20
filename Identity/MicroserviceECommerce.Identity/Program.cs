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
    //OpenIddict core/�ekirdek yap�land�rmalar� ger�ekle�tiriliyor.
    .AddCore(options =>
    {
        //Entity Framework Core kullan�laca�� bildiriliyor.
        options.UseEntityFrameworkCore()
               //Kullan�lacak context nesnesi bildiriliyor.
               .UseDbContext<ApplicationDbContext>();
    })
    //OpenIddict server yap�land�rmalar� ger�ekle�tiriliyor.
    .AddServer(options =>
    {
        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

        // Register the signing credentials.
        options.AddDevelopmentSigningCertificate();
        //Token talebinde bulunulacak endpoint'i set ediyoruz.
        options.SetTokenEndpointUris("/connect/token");
        //Ak�� t�r� olarak Client Credentials Flow'u etkinle�tiriyoruz.
        options.AllowClientCredentialsFlow();
        //Signing ve encryption sertifikalar�n� ekliyoruz.
        options.AddEphemeralEncryptionKey()
               .AddEphemeralSigningKey()
               //Normalde OpenIddict �retilecek token'� g�venlik amac�yla �ifreli bir �ekilde bizlere sunmaktad�r.
               //Haliyle jwt.io sayfas�nda bu token'� ��z�mleyip g�rmek istedi�imizde �ifresinden dolay�
               //incelemede bulunamay�z. Bu DisableAccessTokenEncryption �zelli�i sayesinde �retilen access token'�n
               //�ifrelenmesini iptal ediyoruz.
               .DisableAccessTokenEncryption();
        //OpenIddict Server servislerini IoC Container'a ekliyoruz.
        options.UseAspNetCore()
               //EnableTokenEndpointPassthrough : OpenID Connect request'lerinin OpenIddict taraf�ndan i�lenmesi i�in gerekli konfig�rasyonu sa�lar.
               .EnableTokenEndpointPassthrough();
        //Yetkileri(scope) belirliyoruz.
        options.RegisterScopes("read", "write");
    });

//OpenIddict'i SQL Server'� kullanacak �ekilde yap�land�r�yoruz.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //OpenIddict taraf�ndan ihtiya� duyulan Entity s�n�flar�n� kaydediyoruz.
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
