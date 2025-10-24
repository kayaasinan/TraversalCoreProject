using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SignalRApi",
        Version = "v1"
    });
});

builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", opts =>
    {
        opts.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(host => true);

    });
});


builder.Services.AddDbContext<Context>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalRApi v1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub");
app.Run();
