using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WachtWoord.Models;

namespace WachtWoord.SQLite
{
    internal class WachtContext : DbContext
    {
        public const string DEFAULTDBFILE = "blogging.db";

        public DbSet<Entry> Entries { get; set; }

        private readonly string dbFile = DEFAULTDBFILE;
        private SqliteConnection connection;

        public WachtContext() { }

        public WachtContext(string databaseFile)
        {
            if (!string.IsNullOrEmpty(databaseFile)) dbFile = databaseFile;
        }

        public WachtContext(SqliteConnection sqliteConnection)
        {
            if (!string.IsNullOrEmpty(sqliteConnection?.DataSource)) dbFile = sqliteConnection.DataSource;
            connection = sqliteConnection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connection ??= InitializeSQLiteConnection(dbFile);
            optionsBuilder.UseSqlite(connection);
        }

        private static SqliteConnection InitializeSQLiteConnection(string databaseFile)
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = databaseFile,
                Password = "Test123"// PRAGMA key is being sent from EF Core directly after opening the connection
            };
            return new SqliteConnection(connectionString.ToString());
        }
    }
}
