namespace WachtWoord.Logic.Abstractions
{
    public interface IContextUtil
    {
        bool Exists();
        bool Login(string password);
        bool Create(string password);
        void ChangePassword(string newPassword);
    }
}
