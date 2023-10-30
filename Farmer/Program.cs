using Farmer.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FarmerContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("FarmerConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
var pendingMigration = dbContext.Database.GetPendingMigrations();
if(pendingMigration.Any())
{
    dbContext.Database.Migrate();
}
app.Run();
