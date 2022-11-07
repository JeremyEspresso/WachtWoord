using Microsoft.EntityFrameworkCore;
using WachtWoord.Models.Interfaces;
using WachtWoord.SQLite;

namespace WachtWoord.Models.Services
{
    public class HistoryService
    {
        private readonly Database _db = new();
        
        public async void AddHistory(string password, Entry entry)
        {
            throw new NotImplementedException;
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

        

    }
}
