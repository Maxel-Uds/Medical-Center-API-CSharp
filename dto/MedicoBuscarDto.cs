using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Medical_Center_API_CSharp.dto;

namespace Medical_Center_API_CSharp.model
{
    public class MedicoBuscarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CRM { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Consulta> Consultas { get; set; }

        public MedicoBuscarDto(Medico medico, List<Consulta> consultas) {
            this.Id = medico.Id;
            this.Name = medico.Name;
            this.Email = medico.Email;
            this.Phone = medico.Phone;
            this.CRM = medico.CRM;
            this.CreatedAt = medico.CreatedAt;
            this.Consultas = consultas;
        }
    }
}