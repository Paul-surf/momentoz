using CustomerRestService.BusinesslogicLayer;
using CustomerData.DatabaseLayer;

using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using CustomerRestService.BusinessLogicLayer;
<<<<<<< HEAD
using TicketData.DatabaseLayer;

=======
>>>>>>> bd7ce7fdc6b4cc02f81343fa8e1d8cc8c9eb46f8

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICustomerdata, CustomerdataControl>();
builder.Services.AddSingleton<ICustomerAccess, CustomerDatabaseAccess>();
builder.Services.AddSingleton<ITicketdata, TicketdataControl>();
builder.Services.AddSingleton<ITicketAccess, TicketDatabaseAccess>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();







{
    static void Main()
    {
        // Tilf�j certifikatvalidering
        ServicePointManager.ServerCertificateValidationCallback = ValidateCertificate;

        // Udf�r HTTPS-anmodning til serveren
        using (var client = new WebClient())
        {
            var result = client.DownloadString("https://localhost");
            Console.WriteLine(result);
        }
    }

    // Certifikatvalideringsmetode
    static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Returner "sandt" for at acceptere certifikatet
        return true;
    }
}
