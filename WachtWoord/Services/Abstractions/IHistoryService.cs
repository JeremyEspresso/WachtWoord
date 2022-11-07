namespace WachtWoord.Models.Interfaces
{
    public interface IHistoryService
    {
        void AddHistory(History history);
        void DeleteHistory(History history);
        Task<History?> GetHistory(int id);
        Task<List<History>> GetHistories();
        Task<List<History>> GetEntryHistory(int id);
    }
}
