using Lab2_PWA_Juegos.Data;
using Lab2_PWA_Juegos.Repositories.Customers;
using Lab2_PWA_Juegos.Repositories.Departures;
using Lab2_PWA_Juegos.Repositories.Employees;
using Lab2_PWA_Juegos.Repositories.Entrance;
using Lab2_PWA_Juegos.Repositories.Products;
using Lab2_PWA_Juegos.Repositories.Suppliers;
using Lab2_PWA_Juegos.Services_Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomersRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IEntranceRepository, EntranceRepository>();
builder.Services.AddScoped<IDeparturesRepository, DeparturesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();