using Microsoft.EntityFrameworkCore;
using WachtWoord.Models;
using WachtWoord.Models.Interfaces;
using WachtWoord.SQLite;

namespace WachtWoord.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly Database _db = new();
        
        public async void AddHistory(string password, Entry entry)
        {
            entry.history.Add(new History
            {
                Password = password,
                DateChanged = DateTime.Now
            });
            _db.Update(entry);
            await _db.SaveChangesAsync();
        }

        public async void DeleteHistory(History history)
        {
            if (!await _db.History.ContainsAsync(history)) return;
            _db.History.Remove(history);
            await _db.SaveChangesAsync();
        }

        public async Task<History?> GetHistory(int id)
        {
            return await _db.History.FindAsync(id);
        }

        public async Task<List<History>> GetHistories()
        {
            return await _db.History.ToListAsync();
        }

        public Task<List<History>> GetEntryHistory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
