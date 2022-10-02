using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Medical_Center_API_CSharp.Controllers
{
    [Route("paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DataContext _context;

        public PacienteController(DataContext context) => _context = context;

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult CadastrarPaciente([FromBody] Paciente paciente)
        {
            _context.Paciente.Add(paciente);
            _context.SaveChanges();
            return Created("", paciente);
        }

        [Route("listar")]
        [HttpGet]
        public IActionResult ListarPaciente()
        {
            return Ok(_context.Paciente.ToList());
        }

        Route("listar/{id}")]
        [HttpGet]
        public IActionResult ListarPacienteId([FromRoute] int id)
        {

            Paciente paciente =
                _context.Paciente.FirstOrDefault
            (
                f => f.Id.Equals(id)
            );

            return paciente != null ? Ok(paciente) : NotFound();
        }


        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult DeletarPaciente([FromRoute] int id)
        {
            Paciente paciente = _context.Paciente.Find(id);



            if (paciente != null)
            {

                _context.Paciente.Remove(paciente);
                _context.SaveChanges();
                return Ok(paciente);
            }

            return NotFound("Nenhum paciente foi achado com o id: " + id);
        }

        [Route("alterar")]
        [HttpPatch]
        public IActionResult Alterar([FromBody] Paciente paciente)
        {
            _context.Paciente.Update(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }

    }
}