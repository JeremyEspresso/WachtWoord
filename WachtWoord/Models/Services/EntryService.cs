using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _db.Entries.Add(entry);
            await _db.SaveChangesAsync();
        }

        public async void DeleteEntry(Entry entry)
        {
            _db.Entries.Remove(entry);
            await _db.SaveChangesAsync();
        }

        public List<Entry> GetEntries()
        {
            return _db.Entries.ToList();
        }
        
        public async void UpdateEntry(Entry entry)
        {
            _db.Entries.Update(entry);
            await _db.SaveChangesAsync();
        }

        public int GetEntryCount()
        {
            return _db.Entries.Count();
        }

        public double GetAverageStrength()
        {
            return ((_db.Entries.Any()) ? _db.Entries.Average(e => e.Strength) : 0);
        }
    }
}
