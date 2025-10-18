using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using OfficeOpenXml;
using System.Reflection;
using TraversalCoreProject.Middleware;
using TraversalCoreProject.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<Context>()
  .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(typeof(GuideValidator).Assembly);
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});
ExcelPackage.License.SetNonCommercialPersonal("Sinan Kaya");

var businessAssembly = Assembly.GetAssembly(typeof(DestinationManager));
var dataAccessAssembly = Assembly.GetAssembly(typeof(EfDestinationDal));

foreach (var type in businessAssembly.GetTypes()
             .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Manager")))
{
    var interfaceType = type.GetInterface($"I{type.Name.Replace("Manager", "Service")}");
    if (interfaceType != null)
        builder.Services.AddScoped(interfaceType, type);
}

foreach (var type in dataAccessAssembly.GetTypes()
             .Where(t => t.IsClass && !t.IsAbstract && t.Name.StartsWith("Ef")))
{
    var interfaceType = type.GetInterface($"I{type.Name.Replace("Ef", "")}");
    if (interfaceType != null)
        builder.Services.AddScoped(interfaceType, type);
}


var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();

var path = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
if (!Directory.Exists(path))
    Directory.CreateDirectory(path);

loggerFactory.AddFile($"{path}/Log1.txt");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
//app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseRouting();
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.UseCustom404Page();
app.Run();
