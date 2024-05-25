namespace API.Endpoints
{
    public class APIKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
       
        public APIKeyAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private static readonly List<string> ValidApiKeys = new List<string>
        {
            "my-api-key"
        };

        public bool IsValidApiKey(string apiKey)
        {
            return ValidApiKeys.Contains(apiKey);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-Key", out var potentialApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            if (!IsValidApiKey(potentialApiKey!))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await _next(context);
        }
    }
}
