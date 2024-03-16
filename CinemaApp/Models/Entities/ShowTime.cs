using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class ShowTime
    {
        [Key]
        public int ShowTimeId { get; set; }
        public string  Time { get; set; }

        public ICollection<ShowDetail> showDetails { get; set; }
    }
}