// Inkluderer GuiLayer-navneomr�det fra MomentozClientApp, som indeholder brugergr�nsefladens relaterede klasser.
using MomentozClientApp.GuiLayer;

// Definerer navneomr�det for denne del af applikationen.
namespace MomentozClientApp
{
    // Denne statiske klasse fungerer som startpunktet for applikationen.
    // Den indeholder Main-metoden, der udf�res, n�r programmet starter.
    static class Program
    {
        // STAThreadAttribute angiver, at COM-threadding-modelen for applikationen er single-threaded apartment.
        // Dette er ofte n�dvendigt for Windows Forms applikationer, der interagerer med COM-komponenter.
        [STAThread]
        static void Main()
        {
            // Indstiller applikationens DPI-tilstand, s� den er systembevidst, hvilket hj�lper med at h�ndtere sk�rmopl�sning og skaleringsindstillinger.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Aktiverer visuelle stilarter for applikationen for at bruge aktuelle Windows-temaer.
            Application.EnableVisualStyles();

            // Indstiller 'false' for at bruge GDI+ til tekstrendering, hvilket kan forbedre ydeevnen og reducere kompatibilitetsproblemer.
            Application.SetCompatibleTextRenderingDefault(false);

            // Starter hovedl�kken for applikationen og �bner det f�rste vindue, som er LogIn-formularen.
            Application.Run(new LogIn());
        }
    }
}
