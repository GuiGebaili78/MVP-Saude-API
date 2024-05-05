using Fiap.Api.MVPSaude.Model;
using Fiap.Api.MVPSaude.Repository.Context;
using Fiap.Web.MVPSaude.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Api.MVPSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        private UsuarioRepository usuarioRepository;

        public UsuarioController(DataBaseContext dataBaseContext)
        {

            usuarioRepository = new UsuarioRepository(dataBaseContext);
        }

        [HttpGet]
        public ActionResult<List<UsuarioModel>> Get()
        {
            try
            {
                var lista = usuarioRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet("{id:int}")]
        public ActionResult<UsuarioModel> Get([FromRoute] int id)
        {
            try
            {
                var usuarioModel = usuarioRepository.Consultar(id);

                if (usuarioModel != null)
                {
                    return Ok(usuarioModel);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuarioRepository.Inserir(usuarioModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + usuarioModel.UsuarioId);
                return Created(location, usuarioModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir Médico. Detalhes: {error.Message}" });
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult<UsuarioModel> Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuarioModel.UsuarioId != id)
            {
                return NotFound();
            }

            try
            {
                usuarioRepository.Alterar(usuarioModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar Usuario. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<UsuarioModel> Delete([FromRoute] int id)
        {
            try
            {
                var usuarioModel = usuarioRepository.Consultar(id);

                if (usuarioModel != null)
                {
                    usuarioRepository.Excluir(usuarioModel);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


    }
}