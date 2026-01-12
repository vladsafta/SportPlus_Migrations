using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SportPlus.Data.Repositories;
using SportPlus.Interfaces;
using SportPlus.Repositories;
using SportPlus.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Conexiune la baza de date
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧠 Repository-uri și servicii
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();
builder.Services.AddScoped<ICategorieService, CategorieService>();

builder.Services.AddScoped<IProduseRepository, ProduseRepository>();
builder.Services.AddScoped<IProduseService, ProduseService>();

builder.Services.AddScoped<IComandaRepository, ComandaRepository>();
builder.Services.AddScoped<IComandaService, ComandaService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICosRepository, CosRepository>();
builder.Services.AddScoped<ICosService, CosService>();

// ✅ Autentificare și autorizare
builder.Services.AddAuthentication("AuthCookie")
    .AddCookie("AuthCookie", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

builder.Services.AddAuthorization();

// ✅ Politica cookie – necesară în unele browsere moderne
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🛡️ Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();           //  ajută cu salvarea cookie-urilor
app.UseRouting();

app.UseAuthentication();         //  trebuie înainte de autorizare
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
