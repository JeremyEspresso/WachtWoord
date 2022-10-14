using SQLite;

namespace WachtWoord.Models
{
    internal class Entry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
