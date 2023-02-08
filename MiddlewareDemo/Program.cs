using MiddlewareDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<JokeMiddleware>();
//builder.Services.AddTransient<DadJokeMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        await context.Response.WriteAsync($"Before Request {Environment.NewLine}");
        await next();
        await context.Response.WriteAsync($"After Request {Environment.NewLine}");
    });
    app.UseJokeMiddleware();
    app.UseDadJokeMiddleware();
    app.Map("/first", FirstBranch);
    app.Map("/second", SecondBranch);
   
    app.Run(async context =>
    {
       await context.Response.WriteAsync($"Hello Readers!! {Environment.NewLine}");
    });
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

void SecondBranch(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync($"This is second branch {Environment.NewLine}");
    });
}

void FirstBranch(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync($"This is first branch {Environment.NewLine}");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
