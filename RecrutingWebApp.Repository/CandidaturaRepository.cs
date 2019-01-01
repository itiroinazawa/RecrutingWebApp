using Microsoft.EntityFrameworkCore;
using RecrutingWebApp.Util.Context;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository
{
    public class CandidaturaRepository : ICandidaturaRepository
    {
        private readonly ApiContext _context;

        public CandidaturaRepository(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo responsavel por buscar o ID disponivel
        /// </summary>
        /// <returns>ID disponivel para insercao</returns>
        private async Task<int> GetLastId()
        {
            var candidaturas = await _context.Candidaturas.ToArrayAsync();

            if (candidaturas == null || candidaturas.Count() == 0)
            {
                return 1;
            }
            else
            {
                var lastItem = candidaturas.OrderByDescending(x => x.ID).FirstOrDefault();
                return lastItem.ID + 1;
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar candidatura pelo ID da pessoa e pelo ID da vaga
        /// </summary>
        /// <param name="idPessoa">ID da pessoa</param>
        /// <param name="idVaga">ID da vaga</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Candidatura> GetCandidaturaByPessoaAndVaga(int idPessoa, int idVaga)
        {
            var vagas = await _context.Candidaturas.ToArrayAsync();
            return vagas.FirstOrDefault(x => x.Id_Pessoa == idPessoa && x.Id_Vaga == idVaga);
        }

        /// <summary>
        /// Metodo responsavel por registrar a candidatura
        /// </summary>
        /// <param name="model">Informacoes da candidatura</param>
        /// <returns>Status de cadastro</returns>
        public async Task<bool> RegisterCandidatura(Candidatura model)
        {
            try
            {
                model.ID = await GetLastId();
                _context.Candidaturas.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
