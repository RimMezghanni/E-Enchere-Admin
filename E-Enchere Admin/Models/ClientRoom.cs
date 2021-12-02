using System;
using System.Collections.Generic;

#nullable disable

namespace E_Enchere_Admin.Models
{
    public partial class ClientRoom
    {
        public int IdClient { get; set; }
        public int IdRoom { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
    }
}
