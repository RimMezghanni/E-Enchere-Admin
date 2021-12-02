using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eEnchere.Models
{
    public class Commande
    {
        [Key]
        public int IdCommande { get; set; }
        public string NomCommande { get; set; }
        public DateTime DateCommande{ get; set; }
       // public int IdRoom { get; set; }
        //[ForeignKey("IdRoom")]

        //public Room Room { get; set; }
    }
}
