using Converters.Domain;
using Converters.Domain.Abstractions;
using Converters.Repositories.Contexts;
using Converters.Repositories.DbInitializers;
using Converters.Web.App;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(DefaultConstants.ConnectionStringKey);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ConvertersContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUnitOfWork>(_ => new ConvertersContext(options => options.UseSqlServer(connectionString)));
builder.Services.AddDefaultServices();

await ConvertersDbInitializer.InitializeAsync(new ConvertersContext(options => options.UseSqlServer(connectionString)));

var app = builder.Build();

// Configure the HTTP(S) request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/MicroURL/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MicroURL}/{action=Index}/{id?}");

app.Run();
