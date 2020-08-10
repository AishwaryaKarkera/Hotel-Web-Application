namespace Wanderlust04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   [Table("Reservation")]
    public partial class Reservation
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]

        public int Id { get; set; }


        public DateTime CheckIn { get; set; }





        public DateTime CheckOut { get; set; }


        public int RoomId { get; set; }

        
        
        public string GuestId { get; set; }

        public virtual Guest Guest { get; set; }

        public virtual Room Room { get; set; }
    }
}
