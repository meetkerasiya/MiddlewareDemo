namespace MiddlewareDemo
{
    public class DadJokeMiddleware
    {
        private readonly RequestDelegate _next;

        public DadJokeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"Here's another dad joke for you:{Environment.NewLine}");
            await context.Response.WriteAsync($"When does a joke become a dad joke?{Environment.NewLine}");
            await Task.Delay(2000);
            await context.Response.WriteAsync($"When it becomes apparent.{Environment.NewLine}");

        }
    }

    public static class DadjokeMiddlewareExtensions
    {
        public static IApplicationBuilder UseDadJokeMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DadJokeMiddleware>();
        }
    }
}
