using WachtWoord.Models;

namespace WachtWoord.Services.Interfaces
{
    interface IEntryService
    {
        void AddEntry(Entry entry);
        void DeleteEntry(int Id);
        void UpdateEntry(int Id, Entry entry);
        public List<Entry> GetAllEntries();
        Task<Entry?> GetEntry(int Id);
        int GetEntryCount();
        void FavoriteEntry(Entry entry);
        List<Entry> GetFavorites();
    }
}
