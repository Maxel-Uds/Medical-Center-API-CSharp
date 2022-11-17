using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Medical_Center_API_CSharp.dto;

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

        [Route("buscar/{id}")]
        [HttpGet]
        public IActionResult BuscarMedicoById([FromRoute] int id) {

            Medico medico = _context.Medico.Find(id);

            if(medico == null) {
                return NotFound("Nenhum médico foi encontrado com o id: " + id);
            }

            List<Consulta> consultas = _context.Consulta.Where(consulta => consulta.MedicoId == id)
                .Include(consulta => consulta.Medico)
                .Include(consulta => consulta.Paciente)
                .Include(consulta => consulta.TipoConsulta)
                .ToList();

            return Ok(new MedicoBuscarDto(medico, consultas));
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
        public IActionResult Alterar([FromBody] MedicoUpdateDto medicoDto)
        {
            _context.Medico.Update(Medico.updateMedico(_context.Medico.Find(medicoDto.Id), medicoDto));
            _context.SaveChanges();
            return Ok(medicoDto);
        }
            
    }
}