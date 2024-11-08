using MSO2;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace MSO3
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // AllocConsole() is a function that shows the console for debugging
            //AllocConsole();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Home homePage = Home.GetInstance();
            homePage.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(homePage);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}