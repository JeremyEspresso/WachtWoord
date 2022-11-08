namespace WachtWoord.Services.Interfaces
{
    public interface IDatabaseService
    {
        bool Exists();
        bool Login(string password);
        bool Create(string password);
        void ChangePassword(string newPassword);
    }
}
