using CleanArchWithCQRS.Application;
using CleanArchWithCQRS.Infrastructure;
using CleanArchWithCQRS.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add layer dependency
builder.Services.AddApplicationServices();
builder.Services.AddInfrasructureServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    dataSeeder.SeedData();  // Trigger the seeding process
}
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
