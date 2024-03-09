using AutoMapper;
using SMART.Web.OrderApi;
using Daemon.RazorUI.Modal; 
using SO.Data;
using SO.Components;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddEnvironmentVariables()
    .AddJsonFile("env.json", optional: true, reloadOnChange: true);

// Console.WriteLine("Loaded Environment Variables");
// foreach(var c in builder.Configuration.AsEnumerable()) {
    //     Console.WriteLine(c.Key+"="+c.Value);
// }

// builder.Services
//     .AddAuth0WebAppAuthentication(options => {
//         options.Domain = builder.Configuration["Auth0:Domain"];
//         options.ClientId = builder.Configuration["Auth0:ClientId"];
//     });

//
// ADD SERVICES
//
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var mapperConfig = new MapperConfiguration(cfg => {
    cfg.AddProfile<SmartOrderMappingProfile>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ModalService>();
builder.Services.AddSingleton<SmartOrderApi>();
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

builder.Services.AddRazorPages();


var app = builder.Build();


//
// MIDDLEWARE
//
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Auth0 Authentication Routes
// app.MapGet("/Account/Login", async (HttpContext httpContext, string redirectUri = "/") =>
// {
//   var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
//           .WithRedirectUri(redirectUri)
//           .Build();

//   await httpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
// });

// app.MapGet("/Account/Logout", async (HttpContext httpContext, string redirectUri = "/") =>
// {
//   var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
//           .WithRedirectUri(redirectUri)
//           .Build();

//   await httpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
//   await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
// });
 
// Put this here temporarily for convenience
// Move this this to the login flow
app.Use(async (context, next) => { 
    var config = context.RequestServices.GetRequiredService<IConfiguration>();
    var orderApi = context.RequestServices.GetRequiredService<SmartOrderApi>();
    await orderApi.Login(new ApiCreds(
        config["SMART_FACTORY_ID"]!,
        config["SMART_DEALER_NAME"]!,
        config["SMART_USER_NAME"]!
    ));
    await next();
});


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();