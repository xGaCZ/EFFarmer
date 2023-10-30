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
var dbContext = scope.ServiceProvider.GetRequiredService<FarmerContext>();

var pendingMigration = dbContext.Database.GetPendingMigrations();
if(pendingMigration.Any())
{
    dbContext.Database.Migrate();
}
var animals = dbContext.Animals.ToList();
if(!animals.Any())
{
    var animal1 = new Animal()
    {
        UserId = 1,
        AnimalType = "sheep",
        Name = "puszek",
        Weight = 10,
        LiveTime = 5,
        EatLevel = 5,
        DeadTime = 59,
        GiveEgg = false,
        GiveMilk = true
    };
    var animal2 = new Animal()
    { UserId =1,
        AnimalType = "cow",
        Name = "mucka",
        Weight = 90,
        LiveTime = 40,
        EatLevel = 2,
        DeadTime = 101,
        GiveEgg = false,
        GiveMilk = true
    };
    dbContext.Animals.AddRange(animal1,animal2);
    dbContext.SaveChanges();

}
app.MapPost("update", async (FarmerContext db) =>
{
User userr =await db.Users.FirstOrDefaultAsync(u=>u.Name=="Adam");
    userr.Cash = 1025; ;
    await db.SaveChangesAsync();
    return userr;
});
app.MapGet("data", (FarmerContext db) =>
{
    var user = db.Users.First(u => u.Name == "Adam");
    var milkAnimal = db.Animals.FirstOrDefault(a => a.GiveMilk == true);
    return new { user, milkAnimal };
});

app.Run();

