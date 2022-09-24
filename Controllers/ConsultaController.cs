using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;

namespace Medical_Center_API_CSharp.Controllers
{
    [Route("consulta")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly DataContext _context;

        public ConsultaController(DataContext context) => _context = context;

        [Route("agendar")]
        [HttpPost]
        public IActionResult AgendarConsulta([FromBody] Consulta consulta)
        {
            Consulta _consulta = ConsultaService.CriarConsulta(_context, consulta);
            _context.Consulta.Add(_consulta);
            _context.SaveChanges();
            return Created("", _consulta); 
        }

        [Route("listar")]
        [HttpGet]
        public IActionResult ListarAgendamentos()
        {
            return Ok(_context.Consulta.ToList());
        }

        [Route("cancelar/{id}")]
        [HttpDelete]
        public IActionResult CancelarConsulta([FromRoute] int id)
        {
            Consulta consulta = _context.Consulta.Find(id);

            if(consulta != null)
            {
                _context.Consulta.Remove(consulta);
                _context.SaveChanges();
                return Ok(consulta);
            }

            return NotFound("Nenhuma consulta foi achada com o id: " + id);
        }
    }

    public static class ConsultaService {

        public static Consulta CriarConsulta(DataContext context, Consulta consulta) {
            consulta.Paciente = context.Paciente.Find(consulta.PacienteId);
            consulta.Medico = context.Medico.Find(consulta.MedicoId);
            consulta.TipoConsulta = context.TipoConsulta.Find(consulta.TipoConsultaId);

            return consulta;
        }
    }
}