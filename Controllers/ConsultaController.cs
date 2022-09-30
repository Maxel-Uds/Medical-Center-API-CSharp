using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
            _context.Consulta.Add(consulta);
            _context.SaveChanges();
            return Created("", consulta); 
        }

        [Route("listar")]
        [HttpGet]
        public IActionResult ListarAgendamentos()
        {
            var consultas = _context.Consulta
                .Include(consulta => consulta.Medico)
                .Include(consulta => consulta.Paciente)
                .Include(consulta => consulta.TipoConsulta)
                .ToList();
            
            return Ok(consultas);
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
}