﻿
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WachtWoord.Models;

namespace WachtWoord.SQLite
{
    public class Database : DbContext
    {
        public const string DEFAULTDBFILE = "WachtWoord.db";
        public DbSet<Entry> Entries { get; set; }

        public static string DbPwd { get; set; }
        private SqliteConnection connection;

        public Database() { }
        
        public Database(string databasePassword)
        {
            DbPwd = databasePassword;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connection ??= InitializeSQLiteConnection(DbPwd);
            optionsBuilder.UseSqlite(connection);
        }

        private static SqliteConnection InitializeSQLiteConnection(string databasePassword)
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
                DataSource = DEFAULTDBFILE,
                Password = databasePassword
            };
            return new SqliteConnection(connectionString.ToString());
        }
    }
}
