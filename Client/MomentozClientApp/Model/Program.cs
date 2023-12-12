using MomentozClientApp.GuiLayer;
using MomentozClientApp.Servicelayer;

static class Program
{
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LogIn(new CustomerAccess()));
    }
}
