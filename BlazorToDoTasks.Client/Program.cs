using BlazorToDoTasks.Client.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBlazorBootstrap();

builder.Services.AddQuickGridEntityFrameworkAdapter(); ;
builder.Services.AddHttpClient("DefaultHttpClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiUrls:TasksApi"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
