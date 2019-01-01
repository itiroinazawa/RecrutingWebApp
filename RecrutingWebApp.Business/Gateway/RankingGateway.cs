using RecrutingWebApp.Application.Gateway.Interface;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using RecrutingWebApp.Util.ParserEnum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingWebApp.Application.Gateway
{
    public class RankingGateway : IRankingGateway
    {
        private readonly IRankingRepository _repository;

        public RankingGateway(IRankingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Metodo responsavel por adicionar o candidato a lista de ranking com o score do candidato para a vaga
        /// </summary>
        /// <param name="vaga">Dados da vaga</param>
        /// <param name="pessoa">Dados do candidato</param>
        /// <returns>Status de registro da ranking do candidato a vaga</returns>
        public async Task<bool> AddRankingVaga(Vaga vaga, Pessoa pessoa)
        {
            Ranking model = new Ranking();
            
            CandidateScore calculate = new CandidateScore();
            JobLevelParser parser = new JobLevelParser();

            Enum.TryParse(pessoa.Localizacao, out Location candidateLocation);
            Enum.TryParse(vaga.Localizacao, out Location jobLocation);

            ExperienceLevel candidateLevel = parser.Parse(pessoa.Nivel);
            ExperienceLevel jobLevel = parser.Parse(vaga.Nivel);

            int score = calculate.CalculateCandidateScore(candidateLocation, candidateLevel, jobLocation, jobLevel);

            model.IdVaga = vaga.ID;
            model.Localizacao = pessoa.Localizacao;
            model.Nivel = pessoa.Nivel;
            model.Nome = pessoa.Nome;
            model.Profissao = pessoa.Profissao;
            model.Score = score;            

            return await _repository.AddRankingVaga(model);
        }

        /// <summary>
        /// Metodo responasvel por buscar as vagas pelo ID 
        /// </summary>
        /// <param name="idVaga">ID da vaga</param>
        /// <returns>Lista de Ranking dos candidatos ordenados pelo score</returns>
        public async Task<List<Ranking>> GetRankingVaga(int idVaga)
        {
            return await _repository.GetRankingVaga(idVaga);
        }
    }
}
