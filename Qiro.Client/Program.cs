using Qiro.Client.Features.Blogs.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<BlogService>();

builder.Services
    .AddMudServices()
    .AddMudMarkdownServices()
    .AddBlazoredLocalStorage();

await builder.Build().RunAsync();
