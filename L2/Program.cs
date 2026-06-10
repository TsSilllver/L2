using L2.Data;
using L2.Repositories;
using L2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AnimeDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;";

builder.Services.AddDbContext<AnimeDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IStudioRepository, StudioRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();