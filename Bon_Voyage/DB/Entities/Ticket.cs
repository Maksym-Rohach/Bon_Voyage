using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bon_Voyage.DB.Entities
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public float PriceFrom { get; set; }
        public int CountsOfNight { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool IsBought { get; set; }
        public int CountsOfPlaces { get; set; }
        public int Discount { get; set; }

        public string HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public string AirportId { get; set; }
        public virtual Airport Airport { get; set; }
        public string RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        public string ClientId { get; set; }
        public virtual ClientProfile Client { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<TicketsToComforts> TicketToComforts { get; set; }
    }
}
