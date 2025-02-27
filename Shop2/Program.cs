using Mapster;
using Microsoft.EntityFrameworkCore;
using Shop2;
using Shop2.Database;
using Shop2.Entities;
using Shop2.Mapster;
using Shop2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer("Server=.;Database=myDataBase;Trusted_Connection=True;TrustServerCertificate=true");
})
.AddMapsterConfigs();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=product}/{action=List}/{productId?}/{id?}");

app.Run();

