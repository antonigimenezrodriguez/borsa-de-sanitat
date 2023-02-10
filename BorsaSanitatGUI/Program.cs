using BorsaSanitatGUI.EntityFramework;
using BorsaSanitatGUI.Vista;

namespace BorsaSanitatGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new BorsaSanitatContext())
            {
                context.Database.EnsureCreated();
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Principal());
        }
    }
}