using WachtWoord.Domain.Models;

namespace WachtWoord.Logic.Abstractions
{
    public interface IHistoryService
    {
        void AddHistory(string password, Entry entry);
        void DeleteHistory(History history);
        Task<History?> GetHistory(int id);
        Task<List<History>> GetHistories();
        Task<List<History>> GetEntryHistory(int id);
        
    }
}
