using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;
using HomepageV2.Data.Models;
using HomepageV2.Repos;
using homepageV2.Services;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContextPool<HomepageContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<HomepageContext>();
builder.Services.AddScoped<BlogPostRepository>();
builder.Services.AddScoped<BlogPostService>();

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
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // For your API controllers
app.MapFallbackToFile("index.html");

app.Run();