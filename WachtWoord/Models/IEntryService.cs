using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.Models
{
    internal interface IEntryService
    {
        public void AddEntry(Entry entry);
        public void DeleteEntry(Entry entry);
        public void UpdateEntry(Entry entry);
        public List<Entry> GetEntries();
        
    }
}
