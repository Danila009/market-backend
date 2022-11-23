using Microsoft.AspNetCore.Builder;

namespace Market.WebApi.Middleware
{
    public static class CustomExceptonHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
