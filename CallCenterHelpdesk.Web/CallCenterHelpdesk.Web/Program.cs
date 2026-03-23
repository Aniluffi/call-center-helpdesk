using CallCenterHelpdesk.Data;
using CallCenterHelpdesk.IService;
using CallCenterHelpdesk.Service;
using CallCenterHelpdesk.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Настройка БД
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data")));

// 2. Регистрация сервисов
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IStatusService, StatusService>();

// 3. Поддержка контроллеров и Razor Pages
builder.Services.AddControllers(); // ОБЯЗАТЕЛЬНО для твоих контроллеров
builder.Services.AddRazorPages();

// 4. Swagger (очень рекомендую для тестов API)
builder.Services.AddEndpointsApiExplorer();

// 5. HttpClient для Blazor (если это Blazor Server)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5019/")
});
// В секции builder.Services:
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Настройка конвейера
if (app.Environment.IsDevelopment())
{
    // Можно включить Swagger для тестов:
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery(); // Обязательно для .NET 8 Blazor

app.MapControllers(); // Чтобы работали твои API контроллеры

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/", context =>
{
    context.Response.Redirect("/requests");
    return Task.CompletedTask;
});

app.Run();