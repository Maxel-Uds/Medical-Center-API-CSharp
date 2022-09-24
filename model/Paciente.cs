using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medical_Center_API_CSharp.Validation;

namespace Medical_Center_API_CSharp.model
{
    public class Paciente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório!")]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O número de telefone é obrigatório!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Digite o número com DD e com o dígito 9!")]
        public string Phone { get; set; }
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "O campo cpf é obrigatório!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Digite um CPF válido!")]
        [DocExists]
        public string DocumentNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public virtual List<Consulta> Consultas { get; set; }

        public Paciente(string Name, string Email, string Phone, DateTime Birthday, string DocumentNumber) {
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Birthday = Birthday;
            this.DocumentNumber = DocumentNumber;
            this.CreatedAt = DateTime.Now;
        }
    }
}