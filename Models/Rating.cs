using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wanderlust04.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int rating { get; set; }

        public int ReservationId { get; set; }

        public virtual Reservation reservation { get; set; }
    }
}