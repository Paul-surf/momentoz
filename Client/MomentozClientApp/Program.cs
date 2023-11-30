// Inkluderer GuiLayer-navneområdet fra MomentozClientApp, som indeholder brugergrænsefladens relaterede klasser.
using MomentozClientApp.GuiLayer;

// Definerer navneområdet for denne del af applikationen.
namespace MomentozClientApp
{
    // Denne statiske klasse fungerer som startpunktet for applikationen.
    // Den indeholder Main-metoden, der udføres, når programmet starter.
    static class Program
    {
        // STAThreadAttribute angiver, at COM-threadding-modelen for applikationen er single-threaded apartment.
        // Dette er ofte nødvendigt for Windows Forms applikationer, der interagerer med COM-komponenter.
        [STAThread]
        static void Main()
        {
            // Indstiller applikationens DPI-tilstand, så den er systembevidst, hvilket hjælper med at håndtere skærmopløsning og skaleringsindstillinger.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            // Aktiverer visuelle stilarter for applikationen for at bruge aktuelle Windows-temaer.
            Application.EnableVisualStyles();

            // Indstiller 'false' for at bruge GDI+ til tekstrendering, hvilket kan forbedre ydeevnen og reducere kompatibilitetsproblemer.
            Application.SetCompatibleTextRenderingDefault(false);

            // Starter hovedløkken for applikationen og åbner det første vindue, som er LogIn-formularen.
            Application.Run(new LogIn());
        }
    }
}
