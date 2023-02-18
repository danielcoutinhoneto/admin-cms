using admin_cms.Models.Infraestrutura.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSession();

builder.Services.AddControllersWithViews();

JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
builder.Services.AddDbContext<ContextoCms>(options => options.UseSqlServer(jAppSettings["ConexaoSql"].ToString()));

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

// app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
