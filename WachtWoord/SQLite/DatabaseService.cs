using Microsoft.EntityFrameworkCore;

namespace WachtWoord.SQLite
{
    public class DatabaseService
    {
        public static bool DatabaseExists()
        {
            return File.Exists(Database.DEFAULTDBFILE);
        }
        public static bool Login(string password)
        {
            try
            {
                using var db = new Database(password);
                db.Database.EnsureCreated();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void CreateDatabase(string password)
        {
            Database db = new(password);
            db.Database.EnsureCreated();
        }

        public static void ChangePassword(string newPassword)
        {
            Database db = new();
            var query = @"PRAGMA rekey = '" + newPassword + "';";
            db.Database.ExecuteSqlRaw(query);
        }
    }
}
