using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});



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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



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

app.Run();
