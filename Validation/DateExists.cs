using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;

namespace Medical_Center_API_CSharp.Validation
{
    public class DateExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;

            DataContext context = (DataContext)validationContext.GetService(typeof(DataContext));

            DateTime consultationdate = default;
            Consulta result = context.Consulta.FirstOrDefault(f => f.ConsultationDate.Equals(consultationdate));
            return result == null ? ValidationResult.Success : new ValidationResult("Ja existe uma consulta com esta data:");
        }
    }
}