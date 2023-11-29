using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test4.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "Book title is a required field.")]
        [MaxLength(50)]
        public string? Title { get; set; }

        [Display(Name = "Page Count")]
        [Range(1, int.MaxValue, ErrorMessage = "Page Count must be greater than 0.")]
        [Required(ErrorMessage = "The number of pages is a required field.")]
        public int PageCount { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is a required field.")]
        public Genre Genre { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}

