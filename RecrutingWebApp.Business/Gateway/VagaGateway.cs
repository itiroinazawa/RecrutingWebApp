using System.Threading.Tasks;
using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;

namespace RecrutingWebApp.Application.Gateway
{
    public class VagaGateway : IVagaGateway
    {
        private readonly IVagaRepository _repository;

        public VagaGateway(IVagaRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Metodo responsavel por cadastrar a vaga
        /// </summary>
        /// <param name="model">Informacoes da vaga</param>
        /// <returns>Status de cadastro</returns>
        public async Task<bool> CreateVaga(Vaga model)
        {
            var vaga = await GetVagaByDescricaoAndEmpresa(model.Descricao, model.Empresa);

            if (vaga != null)
                return false;

            return await _repository.CreateVaga(model);
        }

        /// <summary>
        /// Metodo responsavel por buscar a vaga pela descricao e empresa
        /// </summary>
        /// <param name="descricao_">Descricao da vaga</param>
        /// <param name="empresa_">Empresa da vaga</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Vaga> GetVagaByDescricaoAndEmpresa(string descricao_, string empresa_)
        {
            return await _repository.GetVagaByDescricaoAndEmpresa(descricao_, empresa_);
        }

        /// <summary>
        /// Metodo responsavel por buscar a vaga por ID
        /// </summary>
        /// <param name="id">ID da vaga</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Vaga> GetVagaById(int id)
        {
            return await _repository.GetVagaById(id);
        }
    }
}
