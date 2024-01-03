using CurrieTechnologies.Razor.SweetAlert2;
using INTUS;
using INTUS.Services.Implementation;
using INTUS.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSweetAlert2();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<IWindowService,WindowService>();
builder.Services.AddTransient<ISubElementService,SubElementService>();
builder.Services.AddTransient<IOrderService,OrderService>();



await builder.Build().RunAsync();
