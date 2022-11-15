using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Medical_Center_API_CSharp.Validation;

namespace Medical_Center_API_CSharp.dto
{
    public class MedicoDto
    {
        [Required(ErrorMessage = "O campo id é obrigatório!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        [StringLength(11, MinimumLength = 11,ErrorMessage = "Digite o número com DD e com o dígito 9!")]
        public string Phone { get; set; }
        public string CRM { get; set; }

        public MedicoDto(int Id, string Name, string Email, string Phone, string CRM) {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.CRM = CRM;
        }
    }
}