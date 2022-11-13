using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Medical_Center_API_CSharp.Validation;

namespace Medical_Center_API_CSharp.model
{
    public class Consulta
    {
        public int Id { get; set; }
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataExist]
        public DateTime ConsultationDate { get; set; }
        [Required(ErrorMessage = "O tipo de consulta é obrigatória")]
        public int TipoConsultaId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TipoConsulta TipoConsulta { get; set; }
        [Required(ErrorMessage = "Informe um paciente!")]
        public int PacienteId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Paciente Paciente { get; set; }
        [Required(ErrorMessage = "Informe um médico!")]
        public int MedicoId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Medico Medico { get; set; }

        public Consulta(DateTime ConsultationDate, int TipoConsultaId, int PacienteId, int MedicoId) {
            this.ConsultationDate = ConsultationDate;
            this.TipoConsultaId = TipoConsultaId;
            this.PacienteId = PacienteId;
            this.MedicoId = MedicoId;
        }
    }
}