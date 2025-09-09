using Microsoft.EntityFrameworkCore;
using HomepageV2.Data;
using HomepageV2.Data.Models;
using HomepageV2.Repos;
using homepageV2.Services;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContextPool<HomepageContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<HomepageContext>();
builder.Services.AddScoped<BlogPostRepository>();
builder.Services.AddScoped<BlogPostService>();

builder.Services.AddTransient<GlobalErrorHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();