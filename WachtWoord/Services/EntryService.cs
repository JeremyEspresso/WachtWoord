using WachtWoord.BLL;
using WachtWoord.Models.Interfaces;
using WachtWoord.SQLite;
using Zxcvbn;

namespace WachtWoord.Models.Services
{
    public class EntryService : IEntryService
    {
        private readonly Database _db = new();

        public async void AddEntry(Entry entry)
        {
            PasswordGenerator PwGenerator = new(entry.Length);
            entry.Password = PwGenerator.GeneratePassword();
            entry.Strength = (Core.EvaluatePassword(entry.Password).Score * 20) + 20;
            entry.CreationDate = DateTime.Now;
            if (!string.IsNullOrEmpty(entry.URL))
            {
                if (!(entry.URL.StartsWith("http://") || entry.URL.StartsWith("https://")))
                {
                    entry.URL = "https://" + entry.URL;
                }
            }
            _db.Entries.Add(entry);
            await _db.SaveChangesAsync();
        }

        public async void DeleteEntry(Entry entry)
        {
            _db.Entries.Remove(entry);
            await _db.SaveChangesAsync();
        }

        public List<Entry> GetAllEntries() => _db.Entries.ToList();

        public async Task<Entry?> GetEntry(int id) => await _db.Entries.FindAsync(id);

        public async void UpdateEntry(int id, Entry entry)
        {
            var result = _db.Entries.Find(id);
            if (result != null)
            {
                result.Title = entry.Title;
                result.Username = entry.Username;
                result.Password = entry.Password;
                if (!string.IsNullOrEmpty(entry.URL))
                {
                    if (!(entry.URL.StartsWith("http://") || entry.URL.StartsWith("https://")))
                    {
                        entry.URL = "https://" + entry.URL;
                    }
                }
                result.Strength = entry.Strength;
                result.CreationDate = entry.CreationDate;
                result.LastModifiedDate = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }

        public int GetEntryCount() => _db.Entries.Count();

        public double GetAverageStrength() => ((_db.Entries.Any()) ? _db.Entries.Average(e => e.Strength) : 0);

        public List<Entry> GetFavorites() => _db.Entries.Where(e => e.IsFavorite).ToList();

        public async void FavoriteEntry(Entry entry)
        {
            entry.IsFavorite = !entry.IsFavorite;
            _db.Entries.Update(entry);
            await _db.SaveChangesAsync();
        }


    }
}
