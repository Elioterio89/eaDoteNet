using ShoppingNerd.Web.Services;
using ShoppingNerd.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProdutoService, ProdutoService>(
    p => p.BaseAddress = new Uri(builder.Configuration.GetConnectionString("ServicesUrls:ShoppingNerdAPI")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
