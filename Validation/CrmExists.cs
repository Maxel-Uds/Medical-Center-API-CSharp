using System.ComponentModel.DataAnnotations;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;

namespace Medical_Center_API_CSharp.Validation
{
    public class CrmExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            string crm = (string) value;

            DataContext context = (DataContext) validationContext.GetService(typeof(DataContext));

            Medico result = context.Medico.FirstOrDefault(f => f.CRM.Equals(crm));
            return result == null ? ValidationResult.Success : new ValidationResult("Um médico com esse CRM já existe!");
        }
    }
}