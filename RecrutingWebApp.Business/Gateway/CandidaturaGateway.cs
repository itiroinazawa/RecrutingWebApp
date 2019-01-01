using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingWebApp.Application.Gateway
{
    public class CandidaturaGateway : ICandidaturaGateway
    {
        private readonly ICandidaturaRepository _repository;
        private readonly IRankingGateway _rankingGateway;
        private readonly IVagaGateway _vagaGateway;
        private readonly IPessoaGateway _pessoaGateway;

        public CandidaturaGateway(ICandidaturaRepository repository, IRankingGateway rankingGateway, IVagaGateway vagaGateway, IPessoaGateway pessoaGateway)
        {
            _repository = repository;

            _rankingGateway = rankingGateway;
            _pessoaGateway = pessoaGateway;
            _vagaGateway = vagaGateway;
        }

        /// <summary>
        /// Metodo responsavel por buscar a candidatura pelo id da vaga e do candidato
        /// </summary>
        /// <param name="idPessoa">ID do Candidato</param>
        /// <param name="idVaga">ID da Vaga</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Candidatura> GetCandidaturaByPessoaAndVaga(int idPessoa, int idVaga)
        {
            return await _repository.GetCandidaturaByPessoaAndVaga(idPessoa, idVaga);
        }

        /// <summary>
        /// Metodo responsavel por registrar uma candidatura
        /// </summary>
        /// <param name="model">Informacoes da vaga e do candidato</param>
        /// <returns>Status de registro da candidatura</returns>
        public async Task<bool> RegisterCandidatura(Candidatura model)
        {
            var candidatura = await GetCandidaturaByPessoaAndVaga(model.Id_Pessoa, model.Id_Vaga);

            if (candidatura != null)
                return false;

            var result = await _repository.RegisterCandidatura(model);

            if (result)
            {
                Vaga vaga = await _vagaGateway.GetVagaById(model.Id_Vaga);
                Pessoa pessoa = await _pessoaGateway.GetPessoaById(model.Id_Pessoa);

                await _rankingGateway.AddRankingVaga(vaga, pessoa);
            }

            return true;
        }
    }
}
