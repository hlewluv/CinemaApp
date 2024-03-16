using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int RoomId { get; set; }
        public int SeatId { get; set; }
        public bool Status { get; set; }

        public virtual Invoice_Detail InvoiceDetail { get; set; }
    }
}