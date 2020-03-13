using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class RoomType
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
