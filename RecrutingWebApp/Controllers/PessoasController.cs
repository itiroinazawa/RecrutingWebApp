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
    /// Controller responsavel por manipular as informações das pessoas
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PessoasController : Controller
    {
        private readonly IPessoaGateway _gateway;

        public PessoasController(IPessoaGateway gateway)
        {
            _gateway = gateway;
        }

        /// <summary>
        /// Metodo responsavel por cadastrar o candidato
        /// </summary>
        /// <param name="pessoa">Informacoes do candidato</param>
        /// <returns>Response com a mensagem de acordo com a execucao do metodo</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PessoaViewModel pessoa)
        {
            try
            {
                PessoaParser parser = new PessoaParser();
                Pessoa parsedModel = parser.ParseItem(pessoa);

                var result = await _gateway.CreatePessoa(parsedModel);

                if (result)
                {
                    return Ok(new { message = Constantes.Messages.SUCCESS_MESSAGE_POST_PESSOA });
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, new { message = Constantes.Messages.ERROR_MESSAGE_POST_409_PESSOA });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = Constantes.Messages.ERROR_MESSAGE_POST_500 });
            }

        }
    }
}