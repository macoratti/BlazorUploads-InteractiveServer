using BlazorUploads.Components;
using BlazorUploads.Context;
using BlazorUploads.Repositories;
using BlazorUploads.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<AppDbContext>(opt => 
                               opt.UseSqlite(connectionString));

builder.Services.AddTransient<IUploadService, UploadService>();
builder.Services.AddTransient<IUploadRepository, UploadRepository>();
builder.Services.AddHttpClient();

var app = builder.Build();

CreateDatabase(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}
