using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class ShowDay
    {
        [Key]
        public int ShowDayId { get; set; }
        public DateTime Day { get; set; }

        public ICollection<ShowDetail> showDetails { get; set; }


    }
}