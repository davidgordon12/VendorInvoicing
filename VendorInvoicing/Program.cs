using Microsoft.EntityFrameworkCore;
using VendorInvoicing.Data;
using VendorInvoicing.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VendorDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Vendors"));
});

builder.Services.AddScoped<VendorService>();

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
    pattern: "{controller=Vendors}/{action=Index}/{id?}");

app.Run();
