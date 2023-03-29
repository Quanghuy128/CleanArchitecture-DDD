using BuberDinner.Application;
using BuberDinner.Infrastucture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the ioc container.
builder.Services.AddPresentation().AddApplication().AddInfrastucture(builder.Configuration);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());


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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
