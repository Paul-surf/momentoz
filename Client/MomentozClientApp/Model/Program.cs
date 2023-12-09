using MomentozClientApp.GuiLayer;
using MomentozClientApp.Servicelayer;

static class Program
{
    // The main entry point for the application.
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        // Standard initialization code for Windows Forms applications
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Creates a CustomerAccess instance and starts the application with the LogIn form
        Application.Run(new LogIn(new CustomerAccess()));
    }
}
