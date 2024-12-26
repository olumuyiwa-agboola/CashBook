using CashBook.Core.Services;
using CashBook.Infrastructure.Factories;
using CashBook.Core.Abstractions.IServices;
using CashBook.Infrastructure.Repositories;
using CashBook.Core.Abstractions.IFactories;
using CashBook.Core.Abstractions.IRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();