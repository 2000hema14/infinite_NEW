using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MVC_Movie_Assessment1.Modles;

namespace MVC_Movie_Assessment1
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        [Required]
        public string Moviename { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateofRelease { get; set; }
    }
}