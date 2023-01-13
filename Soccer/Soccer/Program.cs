using Microsoft.EntityFrameworkCore;
using Soccer.Data;
using Soccer.Helpers;
using Vereyon.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.AddScoped<IConverterHelper, ConverterHelper>();
builder.Services.AddFlashMessage();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
