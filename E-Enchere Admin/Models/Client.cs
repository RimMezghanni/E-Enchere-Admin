using System;
using System.Collections.Generic;

#nullable disable

namespace E_Enchere_Admin.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientRooms = new HashSet<ClientRoom>();
        }

        public int IdClient { get; set; }
        public string NomClient { get; set; }
        public string PrénomClient { get; set; }
        public string MailClient { get; set; }
        public string MotDePasse { get; set; }
        public double Solde { get; set; }
        public string Pseudo { get; set; }

        public virtual ICollection<ClientRoom> ClientRooms { get; set; }
    }
}
