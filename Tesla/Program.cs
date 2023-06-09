using Microsoft.EntityFrameworkCore;
using Tesla.Core.Services.Cars;
using Tesla.Core.Services.Localisation;
using Tesla.Core.Services.Reservations;
using Tesla.Data;
using Tesla.Data.Database;
using Tesla.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TeslaDbContext>(dbOptions => dbOptions.UseSqlServer(builder.Configuration.GetConnectionString("database")));
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ILocalisationService, LocalisationService>();
builder.Services.AddScoped<ILocalisationRepository, LocalisationRepository>();
builder.Services.AddScoped<ISeeder, Seeder>();
builder.Services.BuildServiceProvider().GetService<ISeeder>().Init();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(options =>  options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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
