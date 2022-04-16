using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConceptArchitect.BookManagement.Validations
{
    public class AuthorAgeRangeAttribute:ValidationAttribute
    {
        public int MinAge { get; set; } = -1; //-1 means don't check
        public int MaxAge { get; set; } = -1; // -1 means don't check


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var author = validationContext.ObjectInstance as Author;

            if (author == null) //this is not an author object
                return ValidationResult.Success;

            var lastDateForAge = author.DeathDate.HasValue ? author.DeathDate.Value : DateTime.Now;

            var age = (int)((lastDateForAge - author.BirthDate).TotalDays / 365);

            if (MinAge > 0 && age < MinAge)
                return new ValidationResult($"Author must be at least {MinAge} years old. Current Age is {age} Years");

            if (MaxAge > 0 && age > MaxAge)
                return new ValidationResult($"Author must be at most {MaxAge} years old. Current Age is {age} years");


            return ValidationResult.Success;    


        }

    }
}




