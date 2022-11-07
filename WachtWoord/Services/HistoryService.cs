using Microsoft.EntityFrameworkCore;
using WachtWoord.Models.Interfaces;
using WachtWoord.SQLite;

namespace WachtWoord.Models.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly Database _db = new();
        public async void AddHistory(History history)
        {
            await _db.History.AddAsync(history);
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

        public async Task<List<History>> GetEntryHistory(int entryId)
        {
            return await _db.History.Where(h => h.entry.Id == entryId).ToListAsync();
        }

    }
}
