using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaApp.Models.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public int RoomId { get; set; }
        public DateTime DayBegin { get; set; }
        public DateTime DayEnd { get; set; }
        public string MovieName { get; set; }
        public string Actor { get; set;}
        public string Description { get; set; }

        public ICollection<ShowDetail> showDetails { get; set; }
    }
}