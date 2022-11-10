namespace WachtWoord.Domain.Models
{
    public class History
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
