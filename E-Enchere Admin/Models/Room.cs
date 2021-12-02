using System;
using System.Collections.Generic;

#nullable disable

namespace E_Enchere_Admin.Models
{
    public partial class Room
    {
        public Room()
        {
            ClientRooms = new HashSet<ClientRoom>();
        }

        public int IdRoom { get; set; }
        public string NomRoom { get; set; }
        public DateTime DateDebut { get; set; }
        public int NombreParticipants { get; set; }
        public int Timeur { get; set; }
        public float MontantEnchére { get; set; }
        public float DernierMise { get; set; }
        public float FraisRoom { get; set; }
        public float MontantLancement { get; set; }
        public float MontantInitial { get; set; }
        public float MontantEnchéreFinal { get; set; }
        public int IdArticle { get; set; }

        public virtual Article IdArticleNavigation { get; set; }
        public virtual ICollection<ClientRoom> ClientRooms { get; set; }
    }
}
