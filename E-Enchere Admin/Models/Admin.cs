using System;
using System.Collections.Generic;

#nullable disable

namespace E_Enchere_Admin.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string PrénomAdmin { get; set; }
        public string NomAdmin { get; set; }
        public string Mail { get; set; }
        public string MotDePasse { get; set; }
    }
}
