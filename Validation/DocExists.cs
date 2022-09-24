using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;

namespace Medical_Center_API_CSharp.Validation
{
    public class DocExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            string document = (string)value;

            DataContext context = (DataContext) validationContext.GetService(typeof(DataContext));

            Paciente result = context.Paciente.FirstOrDefault(f => f.DocumentNumber.Equals(document));
            return result == null ? ValidationResult.Success : new ValidationResult("Um paciente com esse documento já existe!");
        }
    }
}