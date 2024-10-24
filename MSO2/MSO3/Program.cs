using MSO2;
using System.Runtime.InteropServices;

namespace MSO3
{
    internal static class Program
    {
        public static Board board = Board.GetInstance();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AllocConsole();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Board board = Board.GetInstance();
            Home homePage = new Home(board);
            homePage.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(homePage);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}