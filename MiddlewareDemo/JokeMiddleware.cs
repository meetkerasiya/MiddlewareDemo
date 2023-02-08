namespace MiddlewareDemo
{
    public class JokeMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync($"Here's a joke using IMiddleware:{Environment.NewLine}");
           
            await context.Response.WriteAsync($"Diarrhea is hereditary.{Environment.NewLine}");
            await Task.Delay(2000);
            await context.Response.WriteAsync($"Cause, It runs in your jeans.{Environment.NewLine}");
         
            await next(context);
        }
    }

    public static class JokeMiddlewareExtensions
    {
        public static IApplicationBuilder UseJokeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JokeMiddleware>();
        }
    }
}
