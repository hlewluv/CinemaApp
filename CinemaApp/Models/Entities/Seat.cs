using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }
        public int RoomId { get; set; }
        public int SeatRow {  get; set; }
        public char SeatColumn { get; set; }
        public bool Status { get; set; }

        public double Price { get; set; }

        [ForeignKey("Invoice_Detail")]
        public int Invoice_DetailId { get; set; }
        public Invoice_Detail Invoice_Detail { get; set; }

        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}