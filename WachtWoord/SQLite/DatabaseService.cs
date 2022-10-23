using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.SQLite
{
    public class DatabaseService
    {
        public static bool Login(string password)
        {
            try
            {
                using var db = new Database(password);
                db.Database.EnsureCreated();
                return true;
            } catch
            {
                return false;
            }
        }
        public static void CreateDatabase(string password)
        {
            Database db = new Database(password);
            db.Database.EnsureCreated();
        }

        public static void ChangePassword(string password)
        {
            using Database db = new();
            db.Database.ExecuteSqlRaw($"PRAGMA key = '{password}';");
        }
        
        
    }
}
