using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Services;

using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient<IProductService, ProductService>(c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]));
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromSeconds(600))
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "geek_shopping";
    options.ClientSecret = "my_super_secret";
    options.ResponseMode = "code";
    options.ClaimActions.MapJsonKey("role", "role", "role");
    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add("geek_shopping");
    options.SaveTokens = true;
});




var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
