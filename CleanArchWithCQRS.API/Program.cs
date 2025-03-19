using CleanArchWithCQRS.Application;
using CleanArchWithCQRS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add layer dependency
builder.Services.AddApplicationServices();
builder.Services.AddInfrasructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
