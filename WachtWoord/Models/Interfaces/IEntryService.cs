using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.Models.Interfaces
{
    interface IEntryService
    {
        void AddEntry(Entry entry);
        void DeleteEntry(Entry entry);
        void UpdateEntry(int Id, Entry entry);
        public List<Entry> GetAllEntries();
        Task<Entry?> GetEntry(int id);
        int GetEntryCount();
        void FavoriteEntry(Entry entry);
        List<Entry> GetFavorites();
    }
}
