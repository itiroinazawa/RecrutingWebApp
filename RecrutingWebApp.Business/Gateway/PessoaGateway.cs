using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using System.Threading.Tasks;

namespace RecrutingWebApp.Application.Gateway
{
    public class PessoaGateway : IPessoaGateway
    {
        private readonly IPessoaRepository _repository;

        public PessoaGateway(IPessoaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Metodo responsavel por retornar a pessoa pelo nome
        /// </summary>
        /// <param name="name_">Nome do candidato</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Pessoa> GetPessoa(string name_)
        {
            return await _repository.GetPessoaByName(name_);
        }

        /// <summary>
        /// Metodo responsavel por cadastrar o candidato
        /// </summary>
        /// <param name="model">Informacoes referentes ao candidato</param>
        /// <returns>Status de cadastro</returns>
        public async Task<bool> CreatePessoa(Pessoa model)
        {
            var person = await GetPessoa(model.Nome);

            if (person != null)
                return false;

            return await _repository.CreatePessoa(model);
        }

        /// <summary>
        /// Metodo responsavel por buscar a pessoa pelo ID
        /// </summary>
        /// <param name="id">ID da pessoa</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Pessoa> GetPessoaById(int id)
        {
            return await _repository.GetPessoaById(id);
        }
    }
}
