namespace WachtWoord.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public int Strength { get; set; }
    }
}
