using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Contracts.Services;
using Biblioteca.Models.Repositories;
using Biblioteca.Models.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DbContexto");
builder.Services.AddDbContext<DbContexto>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IContextData, ContextDataFake>(); 
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();

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
