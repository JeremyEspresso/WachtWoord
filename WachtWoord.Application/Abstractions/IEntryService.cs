using WachtWoord.Domain.Models;

namespace WachtWoord.Logic.Abstractions
{
    public interface IEntryService
    {
        Task AddEntry(Entry entry);
        Task DeleteEntry(int Id);
        Task UpdateEntry(int Id, Entry entry);
        public List<Entry> GetAllEntries();
        Task<Entry?> GetEntry(int Id);
        int GetEntryCount();
        Task FavoriteEntry(Entry entry);
        List<Entry> GetFavorites();
        double GetAverageStrength();
    }
}
