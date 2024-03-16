using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public bool SeatQuantity { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}