using Microsoft.EntityFrameworkCore;
using WachtWoord.Database;

namespace WachtWoord.Logic.Services
{
    public class DatabaseService
    {

        public static bool Exists()
        {
            return File.Exists(Context.DEFAULTDBFILE);
        }
        /*
         * <summary>
         * Login to the database with the given credentials
         * Returns true if the login was successful
         * </summary>
         * <parameter> string password </parameter>
         * <returns> bool </returns>
         */
        public static bool Login(string password)
        {
            try
            {
                using Context db = new(password);
                db.Database.EnsureCreated();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         * <summary>
         * Create a new database with the given credentials
         * Returns true if the database was created
         * </summary>
         * <parameter> string password </parameter>
         * <returns> bool </returns>
         */
        public static bool Create(string password)
        {
            Context db = new(password);
            return db.Database.EnsureCreated();
        }

        /*
         * <summary>
         * Change the password of the database
         * Returns true if the password was changed
         * </summary>
         * <parameter> string newPassword </parameter>
         * <returns> bool </returns>
         */
        public static void ChangePassword(string newPassword)
        {
            Context db = new();
            var query = @"PRAGMA rekey = '" + newPassword + "';";
            db.Database.ExecuteSqlRaw(query);
        }
    }
}
