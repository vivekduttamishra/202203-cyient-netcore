using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConceptArchitect.BookManagement.Validations
{
    public class UniqueAuthorIdAttribute: ValidationAttribute
    {
        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var id = value as string;
            if (string.IsNullOrEmpty(id))
                return ValidationResult.Success;

            var service = validationContext.GetService(typeof(IAuthorService)) as IAuthorService;

            if (service == null)
                throw new InvalidOperationException("Required Service IAuthorService not configured");
            try
            {
                var existing = service.GetAuthorById(id).Result; //no async operation
                return new ValidationResult($"The id {id} is associated with {existing.Name}");
            }
            catch
            {
                return ValidationResult.Success; //id is not duplicate
            }
            
            
                

            
        }
    }
}
