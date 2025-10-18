namespace TraversalCoreProject.Middleware
{
    public class Custom404Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public Custom404Middleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
        
            await _next(context);

    
            if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
            {
                context.Response.ContentType = "text/html; charset=utf-8";

            
                var filePath = Path.Combine(_env.WebRootPath, "404", "index.html");

                if (File.Exists(filePath))
                {
                    await context.Response.SendFileAsync(filePath);
                }
                else
                {
                    await context.Response.WriteAsync("<h1>404 - Sayfa Bulunamadı</h1>");
                }
            }
        }
    }

    public static class Custom404MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustom404Page(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Custom404Middleware>();
        }
    }
}
