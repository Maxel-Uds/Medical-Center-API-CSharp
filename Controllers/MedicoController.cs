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
        public IActionResult ListarMedicos() {
            return Ok(_context.Medico.ToList());
        }

        [Route("listar/{id}")]
        [HttpGet]
        public IActionResult ListarMedicoId([FromRoute] int id) {

            Medico medico =
                _context.Medico.FirstOrDefault
            (
                f => f.Id.Equals(id)
            );

            return medico != null ? Ok(medico) : NotFound();
        }

        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult DeletarMedico([FromRoute] int id)
        {
            Medico medico = _context.Medico.Find(id);

            if(medico != null)
            {
                _context.Medico.Remove(medico);
                _context.SaveChanges();
                return Ok(medico);
            }

            return NotFound("Nenhum médico foi encontrado com o id: " + id);
        }

        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Medico medico)
        {
            _context.Medico.Update(medico);
            _context.SaveChanges();
            return Ok(medico);
        }
            
    }
}