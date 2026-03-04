using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PersonsApp.DataBase;
using PersonsApp.Services.Persons;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//Add Services to the container 
builder.Services.AddDbContext<PersonsDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddScoped
//builder.Services.Addsingleton
builder.Services.AddTransient<IPersonService, PersonServices>();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

