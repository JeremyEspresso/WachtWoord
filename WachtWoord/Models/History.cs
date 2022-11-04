using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WachtWoord.Models
{
    public class History
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public DateTime DateChanged { get; set; }
        public Entry entry { get; set; }
    }
}
