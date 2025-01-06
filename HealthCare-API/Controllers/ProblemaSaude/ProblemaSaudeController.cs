using HealthCare_API.Content.ProblemaSaude.DTO;
using HealthCare_API.Content.ProblemaSaude.Interfaces;
using HealthCare_API.Content.ProblemaSaude.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare_API.Controllers.ProblemaSaude
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProblemaSaudeController : Controller
    {
        private readonly IProblemaSaudeService _problemaService;

        public ProblemaSaudeController(IProblemaSaudeService problemaService)
        {
            _problemaService = problemaService;
        }

        /// <summary>
        /// Obtém um problema de saúde específico pelo ID.
        /// </summary>
        /// <param name="id">ID do problema de saúde a ser obtido.</param>
        /// <returns>Um objeto <see cref="ProblemaSaudeDTO"/> representando o problema encontrado.</returns>
        /// <response code="200">Retorna o problema de saúde solicitado.</response>
        /// <response code="404">Se o problema de saúde não for encontrado.</response>
        [HttpGet("{id}")]
        public IActionResult GetProblemaById(int id)
        {
            try
            {
                var problemadto = _problemaService.GetProblemaByID(id);
                if (problemadto != null)
                {
                    return Ok(problemadto);
                }
                else
                {
                    return NotFound("Problema não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo problema de saúde.
        /// </summary>
        /// <param name="problemaDTO">Objeto contendo os dados do problema de saúde a ser criado.</param>
        /// <returns>O problema de saúde criado.</returns>
        /// <response code="201">Se o problema for criado com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPost]
        public IActionResult CreateProblema([FromBody] ProblemaSaudeDTO problemaDTO)
        {
            if (problemaDTO == null)
            {
                return BadRequest("O objeto ProblemaSaudeDTO não pode ser nulo.");
            }

            if (problemaDTO.Grau != GrauEnum.Baixo && problemaDTO.Grau != GrauEnum.Medio && problemaDTO.Grau != GrauEnum.Alto)
            {
                return BadRequest("O grau do problema não pode ser diferente de 'Baixo', 'Medio' e 'Alto'.");
            }

            if (ModelState.IsValid)
            {
                _problemaService.AddProblema(problemaDTO);
                return CreatedAtAction(nameof(GetProblemaById), new { id = problemaDTO.Id }, problemaDTO);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Atualiza um problema de saúde existente.
        /// </summary>
        /// <param name="problemaDTO">Objeto contendo os dados do problema de saúde a ser atualizado.</param>
        /// <returns>Confirmação da atualização.</returns>
        /// <response code="200">Se o problema for atualizado com sucesso.</response>
        /// <response code="400">Se os dados fornecidos forem inválidos.</response>
        [HttpPut]
        public IActionResult UpdateProblema([FromBody] ProblemaSaudeDTO problemaDTO)
        {
            if (ModelState.IsValid)
            {
                _problemaService.EditProblema(problemaDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Exclui um problema de saúde pelo ID.
        /// </summary>
        /// <param name="id">ID do problema de saúde a ser excluído.</param>
        /// <returns>Confirmação da exclusão.</returns>
        /// <response code="204">Se o problema for excluído com sucesso.</response>
        /// <response code="404">Se o problema não for encontrado.</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteProblema(int id)
        {
            try
            {
                _problemaService.DeleteProblema(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Obtém a lista de todos os problemas de saúde.
        /// </summary>
        /// <returns>Uma lista de problemas de saúde.</returns>
        /// <response code="200">Se a lista de problemas for retornada com sucesso.</response>
        /// <response code="404">Se nenhum problema for encontrado.</response>
        [HttpGet]
        public IActionResult GetListProblema()
        {
            var problemas = _problemaService.GetListProblemaSaude();
            if (problemas == null || !problemas.Any())
            {
                return NotFound("Nenhum problema de saúde foi encontrado.");
            }
            return Ok(problemas);
        }

        /// <summary>
        /// Obtém uma lista de problemas de saúde por grau.
        /// </summary>
        /// <param name="grau">O grau do problema de saúde (Baixo, Medio, Alto).</param>
        /// <returns>Uma lista de problemas de saúde filtrada pelo grau especificado.</returns>
        /// <response code="200">Se a lista de problemas for retornada com sucesso.</response>
        /// <response code="404">Se nenhum problema for encontrado para o grau especificado.</response>
        [HttpGet]
        public IActionResult GetListaProblemaByGrau(GrauEnum grau)
        {
            var problemas = _problemaService.GetListProblemaSaudeByGrauProblema(grau);
            if (problemas == null || !problemas.Any())
            {
                return NotFound("Nenhum problema de saúde com o grau especificado foi encontrado.");
            }
            return Ok(problemas);
        }
    }
}
