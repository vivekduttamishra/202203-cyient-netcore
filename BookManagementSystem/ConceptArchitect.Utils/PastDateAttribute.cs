using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConceptArchitect.Utils
{
    public class PastDateAttribute:ValidationAttribute
    {
        public int MinDays { get; set; } = 1;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
                return ValidationResult.Success; //I don't care. It's not me to judge

            var date = (DateTime)value;
            var today = DateTime.Now;

            var diff = today - date;

            var days = (int)diff.TotalDays;

            if (days >= MinDays)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage ?? $"Date should be {MinDays} days in Past. Actual Value {days}");


        }
    }
}
