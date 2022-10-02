using Microsoft.AspNetCore.Mvc;
using Medical_Center_API_CSharp.model;
using Medical_Center_API_CSharp.Repository;

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
    }
}