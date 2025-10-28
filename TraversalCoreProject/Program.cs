using BusinessLayer.Concrete;
using BusinessLayer.Mapping;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using System.Globalization;
using System.Reflection;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.Middleware;
using TraversalCoreProject.Validations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<Context>()
  .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<DeleteDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAutoMapper(typeof(GuideMapping).Assembly);
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

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});
builder.Services.AddHttpClient();

ExcelPackage.License.SetNonCommercialPersonal("Sinan Kaya");

var businessAssembly = Assembly.GetAssembly(typeof(DestinationManager));
var dataAccessAssembly = Assembly.GetAssembly(typeof(EfDestinationDal));

builder.Services.AddScoped<IUOWDal, UOWDal>();
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
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
});
var supportedCultures = new[]
{
    new CultureInfo("tr"),
    new CultureInfo("en"),
    new CultureInfo("ru"),
    new CultureInfo("fr"),
    new CultureInfo("es")
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});

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
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value;
if (localizationOptions != null)
    app.UseRequestLocalization(localizationOptions);


app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

//app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.UseCustom404Page();
app.Run();
