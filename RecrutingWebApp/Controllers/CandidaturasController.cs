using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Model;
using RecrutingWebApp.Util;
using System;
using System.Threading.Tasks;

namespace RecrutingWebApp.Controllers
{
    /// <summary>
    /// Controller responsavel por manipular as candidaturas
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class CandidaturasController : Controller
    {
        private readonly ICandidaturaGateway _gateway;

        public CandidaturasController(ICandidaturaGateway gateway)
        {
            _gateway = gateway;
        }

        /// <summary>
        /// Metodo responsavel pela criação de candidaturas associando a vaga ao candidato
        /// </summary>
        /// <param name="candidatura">Objeto que recebe o id da vaga e id da pessoa</param>
        /// <returns>Response com a mensagem de acordo com a execucao do metodo</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Candidatura candidatura)
        {
            try
            {
                Candidatura model = new Candidatura() { Id_Pessoa = candidatura.Id_Pessoa, Id_Vaga = candidatura.Id_Vaga };
                var result = await _gateway.RegisterCandidatura(model);

                if (result)
                {
                    return Ok(new { message = Constantes.Messages.SUCCESS_MESSAGE_POST_CANDIDATURA });
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, new { message = Constantes.Messages.ERROR_MESSAGE_POST_409_CANDIDATURA });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = Constantes.Messages.ERROR_MESSAGE_POST_500 });
            }
        }     
    }
}