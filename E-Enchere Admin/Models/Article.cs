using System;
using System.Collections.Generic;

#nullable disable

namespace E_Enchere_Admin.Models
{
    public partial class Article
    {
        public Article()
        {
            Rooms = new HashSet<Room>();
        }

        public int IdArticle { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int Prix { get; set; }
        public string Photo { get; set; }
        public string Etat { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
