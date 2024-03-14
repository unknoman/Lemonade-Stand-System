using AutoMapper;
using Business;
using Business.Resources;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Models;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//------- Configurations

//---- logger

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); 
    logging.AddConsole(); 
    logging.AddDebug(); 
});

//-------------- AutoMap
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

var mapper = config.CreateMapper();


// -- ConnectionString
builder.Services.AddDbContext<LemonadeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

//----Cycles
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//-----------

// Registered services 
builder.Services.AddScoped<ProductData>();
builder.Services.AddScoped<ProductBusiness>();
builder.Services.AddSingleton<IMapper>(mapper);

//---------------




var app = builder.Build();

//-----------------
/*
using (var scope = app.Services.CreateScope())
{
    LemonadeDbContext lemonadeDbContext = scope.ServiceProvider.GetRequiredService<LemonadeDbContext>();
    // lemonadeDbContext.Database.EnsureCreated();
  
} */

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
