using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;

using SalesWebMVCNew.Data;
using SalesWebMVCNew.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

string strConnection = builder.Configuration.GetConnectionString("SalesWebMVCNewContext");

builder.Services.AddTransient<SeedingService>();

builder.Services.AddDbContextPool<SalesWebMVCNewContext>(options => options.UseMySql(strConnection, ServerVersion.AutoDetect(strConnection)));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();

builder.Services.AddScoped<SellerService>();

builder.Services.AddScoped<DepartmentService>();

var app = builder.Build();

var enUs = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUs),
    SupportedCultures = new List<CultureInfo> { enUs },
    SupportedUICultures = new List<CultureInfo> { enUs }
};

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    SeedData(app);   
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedingService>();
        service.Seed();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
