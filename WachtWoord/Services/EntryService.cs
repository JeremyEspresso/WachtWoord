using Microsoft.EntityFrameworkCore;
using WachtWoord.BLL;
using WachtWoord.Models;
using WachtWoord.Services.Interfaces;
using WachtWoord.SQLite;
using Zxcvbn;

namespace WachtWoord.Services
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

        public async void DeleteEntry(int Id)
        {
            var entryToDelete = _db.Entries.Include(e => e.history).FirstOrDefault(e => e.Id == Id);
            if (entryToDelete == null) return;
            _db.Entries.Remove(entryToDelete);
            await _db.SaveChangesAsync();
        }

        public List<Entry> GetAllEntries() => _db.Entries.ToList();

        public async Task<Entry?> GetEntry(int id) => await _db.Entries.FindAsync(id);

        public async void UpdateEntry(int Id, Entry entry)
        {
            var result = _db.Entries.Find(Id);
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
