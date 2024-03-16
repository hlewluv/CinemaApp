using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class Invoice_Detail
    {
        [Key]
        public int Invoice_DetailId { get; set; }
        public int SeatId { get; set; }
        public bool Status { get; set; }
        public string AccountId { get; set; }


        public ApplicationUser Account { get; set; }
        [Required]

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        public ICollection<Seat> Seats { get; set; }

        [ForeignKey("Ticket")]
        public int TicketID { get; set; }
        public virtual Ticket Ticket { get; set; }

        [ForeignKey("ShowDetail")]
        public int ShowDetailID { get; set; }
        public ShowDetail ShowDetail { get; set; }
        
    }
}