using Fiap.Api.MVPSaude.Model;
using Fiap.Api.MVPSaude.Repository.Context;
using Fiap.Web.MVPSaude.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Fiap.Api.MVPSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : Controller
    {

        private ConsultaRepository consultaRepository;

        public ConsultaRepository(DataBaseContext dataBaseContext)
        {

            consultaRepository = new ConsultaRepository(dataBaseContext);
        }

        [HttpGet]
        public ActionResult<List<ConsultaModel>> Get()
        {
            try
            {
                var lista = consultaRepository.Listar();

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
        public ActionResult<ConsultaModel> Get([FromRoute] int id)
        {
            try
            {
                var consultaModel = consultaRepository.Consultar(id);

                if (consultaModel != null)
                {
                    return Ok(consultaModel);
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
        public ActionResult<ConsultaModel> Post([FromBody] ConsultaModel consultaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                consultaRepository.Inserir(consultaModel);

                var location = new Uri(Request.GetEncodedUrl() + "/" + consultaModel.ConsultaId);
                return Created(location, consultaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a consulta. Detalhes: {error.Message}" });
            }
        }


        [HttpPut("{id:int}")]
        public ActionResult<ConsultaModel> Put([FromRoute] int id, [FromBody] ConsultaModel consultaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (consultaModel.ConsultaId != id)
            {
                return NotFound();
            }

            try
            {
                consultaRepository.Alterar(consultaModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a consulta. Detalhes: {error.Message}" });
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult<ConsultaModel> Delete([FromRoute] int id)
        {
            try
            {
                var consultaModel = consultaRepository.Consultar(id);

                if (consultaModel != null)
                {
                    consultaRepository.Excluir(consultaModel);
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