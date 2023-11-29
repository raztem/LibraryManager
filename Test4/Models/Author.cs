using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test4.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is a required field.")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth is a required field.")]
        public DateTime BirthDate { get; set; }

        public List<Book>? Books { get; set; }
    }
}

