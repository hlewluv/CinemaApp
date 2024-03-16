using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class ShowDetail
    {
        [Key]
        public int ShowDetailId { get; set; }

        public virtual Invoice_Detail InvoiceDetail { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("ShowDay")]
        public int ShowDayID { get; set; }
        public ShowDay ShowDay { get; set; }

        [ForeignKey("ShowTime")]
        public int ShowTimeID { get; set; }
        public ShowTime ShowTime { get; set; }

    }
}