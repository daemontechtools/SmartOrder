using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;
using SMART.Web.OrderApi;
using Daemon.RazorUI.Modal; 
using SmartEstimate.Models;
using SmartEstimate.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("env.json", optional: true, reloadOnChange: true);

// Console.WriteLine("Loaded Environment Variables");
// foreach(var c in builder.Configuration.AsEnumerable()) {
//     Console.WriteLine(c.Key+"="+c.Value);
// }


builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add AutoMapper profile
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<SmartEstimateMappingProfile>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ModalService>();
// TODO: This should work as Scoped
builder.Services.AddSingleton<OrderApi>();
builder.Services.AddSingleton<ProjectApi>();
builder.Services.AddSingleton<ProjectStore>();
builder.Services.AddSingleton<ShipLocationApi>();
builder.Services.AddSingleton<ShipLocationStore>();


builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();

// app.MapBlazorHub();
// app.MapFallbackToPage("App");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") =>
{
  var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
          .WithRedirectUri(redirectUri)
          .Build();

  await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") =>
{
  var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
          .WithRedirectUri(redirectUri)
          .Build();

  await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
  await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();