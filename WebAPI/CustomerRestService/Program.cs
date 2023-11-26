using RESTfulService.BusinesslogicLayer;
using DatabaseData.DatabaseLayer;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using RESTfulService.BusinessLogicLayer;
using RESTfulService.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICustomerdata, CustomerdataControl>();
builder.Services.AddSingleton<ICustomerAccess, CustomerDatabaseAccess>();
builder.Services.AddSingleton<ITicketdata, TicketdataControl>();
builder.Services.AddSingleton<ITicketAccess, TicketDatabaseAccess>();
builder.Services.AddSingleton<IFlightdata, FlightdataControl>();
builder.Services.AddSingleton<IFlightAccess, FlightDatabaseAccess>();
builder.Services.AddSingleton<IOrderdata, OrderdataControl>();
builder.Services.AddSingleton<IOrderAccess, OrderDatabaseAccess>();
builder.Services.AddSingleton<IBaggagedata, BaggageDataControl>();
builder.Services.AddSingleton<IBaggageAccess, BaggageDatabaseAccess>();
builder.Services.AddAuthorization();
builder.Services.AddControllers(); 
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();


