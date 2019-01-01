using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Model;
using RecrutingWebApp.Parser;
using RecrutingWebApp.Util;
using System;
using System.Threading.Tasks;

namespace RecrutingWebApp.Controllers
{
    /// <summary>
    /// Metodo responsavel por manipular as informacoes de vagas
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class VagasController : Controller
    {
        private readonly IVagaGateway _gateway;
        private readonly IRankingGateway _rankingGateway;

        public VagasController(IVagaGateway gateway, IRankingGateway rankingGateway)
        {
            _gateway = gateway;
            _rankingGateway = rankingGateway;
        }

        /// <summary>
        /// Metodo responsavel por retornar as candidaturas de uma determinada vaga ordenadas pelo ranking
        /// </summary>
        /// <param name="id">ID da Vaga</param>
        /// <returns>Response da lista de candidatos ordenados por ranking</returns>
        [HttpGet("{id}/candidaturas/ranking")]
        public async Task<IActionResult> GetCandidaturasRanking(int id)
        {
            RankingParser parser = new RankingParser();

            var result = await _rankingGateway.GetRankingVaga(id);            

            var ranking = parser.ParseList(result);

            return Ok(ranking);
        }

        /// <summary>
        /// Metodo responsavel por cadastrar as vagas
        /// </summary>
        /// <param name="vaga">Informacoes de acordo com a vaga</param>
        /// <returns>Response com a mensagem de acordo com a execucao do metodo</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]VagaViewModel vaga)
        {
            try
            {
                VagaParser parser = new VagaParser();
                Vaga parsedModel = parser.ParseItem(vaga);                

                var result = await _gateway.CreateVaga(parsedModel);

                if (result)
                {
                    return Ok(new { message = Constantes.Messages.ERROR_MESSAGE_POST_409_VAGAS });
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, new { message = Constantes.Messages.ERROR_MESSAGE_POST_409_VAGAS });
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = Constantes.Messages.ERROR_MESSAGE_POST_500 });
            }
        }
    }
}