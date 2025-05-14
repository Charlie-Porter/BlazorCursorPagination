using CursorPagination.Components;
using CursorPagination.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddHttpClient<RedditService>(client =>
       {
           client.BaseAddress = new Uri("https://www.reddit.com/");
           client.DefaultRequestHeaders.UserAgent.ParseAdd("CursorDemo/1.0");
       });

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(CursorPagination.Client._Imports).Assembly);

app.Run();
