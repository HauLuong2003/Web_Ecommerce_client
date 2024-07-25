using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Diagnostics.Metrics;
using Web_Ecommerce_Cilent;
using Ecommerce_Models.Service;
using Web_Ecommerce_Cilent.Service;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IBrand, BrandService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IImage, ImageService>();
builder.Services.AddScoped<IOrderManage,OrderService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7095/") });

await builder.Build().RunAsync();
