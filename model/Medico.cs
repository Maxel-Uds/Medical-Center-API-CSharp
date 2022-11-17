using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Medical_Center_API_CSharp.Validation;
using Medical_Center_API_CSharp.dto;

namespace Medical_Center_API_CSharp.model
{
    public class Medico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        [StringLength(11, MinimumLength = 11,ErrorMessage = "Digite o número com DD e com o dígito 9!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Informe um CRM válido para cadastrar o médico!")]
        [CrmExists]
        public string CRM { get; set; }
        public DateTime CreatedAt { get; set; }

        public Medico(string Name, string Email, string Phone, string CRM) {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.CRM = CRM;
            this.CreatedAt = DateTime.Now;
        }

        public static Medico updateMedico(Medico medico, MedicoUpdateDto medicoDto) {
            medico.Name = medicoDto.Name;
            medico.Email = medicoDto.Email;
            medico.Phone = medicoDto.Phone;
            return medico;
        } 
    }
}