

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;

namespace Medical_Center_API_CSharp.Validation
{
    public class DataExist: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;

            DataContext context = (DataContext)validationContext.GetService(typeof(DataContext));

            Consulta result = context.Consulta.FirstOrDefault(f => f.ConsultationDate.Equals(date));
            return result == null ? ValidationResult.Success : new ValidationResult("Ja existe uma consulta com esta data:");
        }
    }
}