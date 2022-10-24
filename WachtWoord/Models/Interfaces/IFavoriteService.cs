using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.Models.Interfaces
{
    interface IFavoriteService
    {
        public void AddEntry(Favorite favorite);
        public void DeleteEntry(Favorite favorite);
        public void UpdateEntry(Favorite favorite);
        public List<Entry> GetEntries();
    }

}
