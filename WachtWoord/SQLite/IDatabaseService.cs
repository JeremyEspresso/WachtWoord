using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.SQLite
{
    public interface IDatabaseService
    {
        bool Exists();
        bool Login(string password);
        bool Create(string password);
        void ChangePassword(string newPassword);
    }
}
