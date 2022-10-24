using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WachtWoord.BLL;
using WachtWoord.Models;
using WachtWoord.SQLite;

namespace WachtWoord
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Settings.Create();
            ApplicationConfiguration.Initialize();
            Application.Run(new Window());
        }
    }
}
