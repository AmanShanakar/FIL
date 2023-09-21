using BasicAuthentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//UseMiddleware is used to add middleware components to the pipeline annd type of middleware is BasicAuthHandler
app.UseMiddleware<BasicAuthHandler>("Test"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
