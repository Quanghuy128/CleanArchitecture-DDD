using BuberDinner.API.Errors;
using BuberDinner.API.Filter;
using BuberDinner.API.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastucture;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the ioc container.
builder.Services.AddApplication().AddInfrastucture(builder.Configuration);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnnerProblemDetailFactory>();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");

//app.Map("/error", (HttpContext httpContext) =>
//{
//    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//    return Results.Problem();
//});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
