using E_Enchere_Admin.Models;
using eEnchere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eEnchere.Data
{
    public class Client_Room
    {
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public int IdRoom { get; set; } 
        public Room  Room { get; set; }
    }
}
