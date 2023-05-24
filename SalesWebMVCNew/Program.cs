using Microsoft.EntityFrameworkCore;

using SalesWebMVCNew.Data;
using SalesWebMVCNew.Services;

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
