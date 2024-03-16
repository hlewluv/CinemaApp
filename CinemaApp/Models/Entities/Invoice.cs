using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public bool Status { get; set; }
        public DateTime DateCreate { get; set; }
        public string AccountId { get; set; }
        public ApplicationUser Account { get; set; }
        public virtual Invoice_Detail InvoiceDetail { get; set; }
    }
}