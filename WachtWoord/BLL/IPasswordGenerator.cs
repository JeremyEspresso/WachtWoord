using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WachtWoord.Models;

namespace WachtWoord.BLL
{
    internal interface IPasswordGenerator
    {   
        public string GeneratePassword();
        public string GenerateCharacters();
    }
}
