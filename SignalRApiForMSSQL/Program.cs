using Microsoft.EntityFrameworkCore;
using SignalRApiForMSSQL.DAL;
using SignalRApiForMSSQL.Hubs;
using SignalRApiForMSSQL.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(opt =>

    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", opts =>
    {
        opts.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(host => true);

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi v1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub");
app.Run();
