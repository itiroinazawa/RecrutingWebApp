using Microsoft.EntityFrameworkCore;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using RecrutingWebApp.Util.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository
{
    public class RankingRepository : IRankingRepository
    {
        private readonly ApiContext _context;

        public RankingRepository(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo responsavel por buscar o ID disponivel
        /// </summary>
        /// <returns>ID disponivel para insercao</returns>
        private async Task<int> GetLastId()
        {
            var rankings = await _context.RankingVagas.ToArrayAsync();

            if (rankings == null || rankings.Count() == 0)
            {
                return 1;
            }
            else
            {
                var lastItem = rankings.OrderByDescending(x => x.ID).FirstOrDefault();
                return lastItem.ID + 1;
            }
        }
        
        /// <summary>
        /// Metodo responsavel por adicionar o ranking do candidato a vaga 
        /// </summary>
        /// <param name="model">Informacoes do ranking</param>
        /// <returns>Status de cadastro</returns>
        public async Task<bool> AddRankingVaga(Ranking model)
        {
            try
            {
                model.ID = await GetLastId();

                _context.RankingVagas.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar os candidatos rankeados por ordem decrescentes pelo ID da vaga
        /// </summary>
        /// <param name="idVaga">ID da vaga</param>
        /// <returns>Lista de candidatos rankeados</returns>
        public async Task<List<Ranking>> GetRankingVaga(int idVaga)
        {
            var candidaturas = await _context.RankingVagas.ToArrayAsync();
            return candidaturas.Where(x => x.IdVaga == idVaga).ToList();
        }
    }
}
