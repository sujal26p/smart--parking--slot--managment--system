using SmartParkingPro.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(options => options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter()));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => { options.LoginPath = "/Account/Login"; options.AccessDeniedPath = "/Account/Login"; options.ExpireTimeSpan = TimeSpan.FromHours(8); options.Cookie.HttpOnly = true; options.Cookie.SameSite = SameSiteMode.Lax; });
builder.Services.AddAuthorization();
builder.Services.AddSingleton<AuthStore>();
builder.Services.AddSingleton<ParkingStore>();
var app = builder.Build();
// Check MySQL and create required tables before accepting requests.
_ = app.Services.GetRequiredService<AuthStore>();
_ = app.Services.GetRequiredService<ParkingStore>();
if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
