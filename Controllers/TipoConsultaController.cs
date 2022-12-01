using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Medical_Center_API_CSharp.Controllers
{
    [Route("consulta/tipo")]
    [ApiController]
    public class TipoConsultaController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoConsultaController(DataContext context) => _context = context;

        [Route("criar")]
        [HttpPost]
        public IActionResult CriarNovoTipo([FromBody] TipoConsulta tipo)
        {
            _context.TipoConsulta.Add(tipo);
            _context.SaveChanges();
            return Created("", tipo);
        }

        [Route("listar")]
        [HttpGet]
        public IActionResult ListarTipoConsulta() {
            return Ok(_context.TipoConsulta.ToList());
        }

        [Route("buscar/{id}")]
        [HttpGet]
        public IActionResult BuscarTipoConsultaById([FromRoute] int id)
        {
            TipoConsulta tipoConsulta = _context.TipoConsulta.Find(id);
            return tipoConsulta != null ? Ok(tipoConsulta) : NotFound("Nenhum tipo de consulta foi achado com o id: " + id);
        }
        
        [Route("deletar/{id}")]
        [HttpDelete]
        public IActionResult DeletarTipoConsulta([FromRoute] int id)
        {
            TipoConsulta tipoconsulta = _context.TipoConsulta.Find(id);



            if (tipoconsulta != null)
            {

                _context.TipoConsulta.Remove(tipoconsulta);
                _context.SaveChanges();
                return Ok(tipoconsulta);
            }

            return NotFound("Nenhum tipo de consulta foi encontrado com o id: " + id);
        }
    }
}