using System.ComponentModel.DataAnnotations;

namespace Medical_Center_API_CSharp.model
{
    public class TipoConsulta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo da descrição é obrigatória!")]
        public string Description { get; set; }

        public TipoConsulta(string Name, string Description) {
            this.Name = Name;
            this.Description = Description;
        }
    }
}