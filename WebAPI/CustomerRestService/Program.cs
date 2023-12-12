using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RESTfulService.BusinesslogicLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.BusinessLogicLayer;
using System.Text;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

// Add services to the container.
builder.Services.AddSingleton<ICustomerdata, CustomerdataControl>();
builder.Services.AddSingleton<ICustomerAccess, CustomerDatabaseAccess>();
builder.Services.AddSingleton<IFlightdata, FlightdataControl>();
builder.Services.AddSingleton<IFlightAccess, FlightDatabaseAccess>();
builder.Services.AddSingleton<IOrderdata, OrderdataControl>();
builder.Services.AddSingleton<IOrderAccess, OrderDatabaseAccess>();
builder.Services.AddControllers();
//builder.Services.AddDbContext<YourDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Momentoz")));


// Tilføjer JWT-autentificering
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true
        // Eventuelt tilføj yderligere valideringsparametre her
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
