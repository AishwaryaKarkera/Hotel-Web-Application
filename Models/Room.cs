namespace Wanderlust04.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Room
    {
       
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]


        public int Id { get; set; }



        public string RoomType { get; set; }

        
        
        public string RoomStatus { get; set; }



        public int MaxNumber { get; set; }

       
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
