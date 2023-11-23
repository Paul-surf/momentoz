using CustomerRestService.BusinesslogicLayer;
using DatabaseData.DatabaseLayer;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using CustomerRestService.BusinessLogicLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICustomerdata, CustomerdataControl>();
builder.Services.AddSingleton<ICustomerAccess, CustomerDatabaseAccess>();
builder.Services.AddSingleton<ITicketdata, TicketdataControl>();
builder.Services.AddSingleton<ITicketAccess, TicketDatabaseAccess>();
builder.Services.AddSingleton<IFlightdata, FlightdataControl>();
builder.Services.AddSingleton<IFlightAccess, FlightDatabaseAccess>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();


app.Run();
