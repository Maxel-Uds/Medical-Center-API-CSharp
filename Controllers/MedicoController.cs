using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Medical_Center_API_CSharp.Controllers
{
    [Route("medico")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DataContext _context;

        public MedicoController(DataContext context) => _context = context;

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult CadastrarMedico([FromBody] Medico medico)
        {
            _context.Medico.Add(medico);
            _context.SaveChanges();
            return Created("", medico); 
        }

        [Route("listar")]
        [HttpGet]
        public IActionResult ListarConsultas() {
            return Ok(_context.Medico.ToList());
        }
            
    }
}