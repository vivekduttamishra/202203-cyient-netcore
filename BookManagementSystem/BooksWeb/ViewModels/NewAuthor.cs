using ConceptArchitect.BookManagement.Validations;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWeb.ViewModels
{
    //New Author View Model
    public class NewAuthor
    {

        [Required]
        [UniqueAuthorId] //--> this id is need only during create
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        [WordCount(Min = 10, ErrorMessage = "Biography must have at least 10 words")]
        public string Biography { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [PastDate(MinDays = 3652, ErrorMessage = "Author Must be at least 10 Years old")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [PastDate]
        public DateTime? DeathDate { get; set; } //optional

       
    }
}
