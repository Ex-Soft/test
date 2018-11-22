using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [StringLength(256, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        //[Required]
        [StringLength(256)]
        public string Genre { get; set; }

        //[Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        //[StringLength(5)]
        //public string Rating { get; set; }
    }
}