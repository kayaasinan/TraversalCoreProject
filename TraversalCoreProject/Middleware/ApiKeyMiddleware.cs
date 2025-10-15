using Microsoft.Extensions.Configuration;

namespace TraversalCoreProject.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKeyHeaderName;
        private readonly string _validApiKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;

            // Sabitler yerine appsettings'ten oku
            _apiKeyHeaderName = configuration["ApiKeySettings:HeaderName"];
            _validApiKey = configuration["ApiKeySettings:ValidApiKey"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Eğer istek /api ile başlamıyorsa, middleware'i atla
            if (!context.Request.Path.StartsWithSegments("/api"))
            {
                await _next(context);
                return;
            }

            // Header var mı kontrol et
            if (!context.Request.Headers.TryGetValue(_apiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key eksik");
                return;
            }

            // Key doğru mu
            if (!_validApiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Geçersiz API Key");
                return;
            }

            try
            {
                await _next(context);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

