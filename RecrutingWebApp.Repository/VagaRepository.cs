using Microsoft.EntityFrameworkCore;
using RecrutingWebApp.Util.Context;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository
{
    public class VagaRepository : IVagaRepository
    {
        private readonly ApiContext _context;

        public VagaRepository(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo responsavel por buscar o ID disponivel
        /// </summary>
        /// <returns>ID disponivel para insercao</returns>
        private async Task<int> GetLastId()
        {
            var vagas = await _context.Vagas.ToArrayAsync();

            if (vagas == null || vagas.Count() == 0)
            {
                return 1;
            }
            else
            {
                var lastItem = vagas.OrderByDescending(x => x.ID).FirstOrDefault();
                return lastItem.ID + 1;
            }
        }

        /// <summary>
        /// Metodo responsavel por cadastrar a vaga
        /// </summary>
        /// <param name="model">Informacoes da vaga</param>
        /// <returns>Status de cadastro</returns>
        public async Task<bool> CreateVaga(Vaga model)
        {
            try
            {
                model.ID = await GetLastId();

                _context.Vagas.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar a vaga de acordo com a descricao e a empresa
        /// </summary>
        /// <param name="descricao_">Descricao da vaga</param>
        /// <param name="empresa_">Empresa da vaga</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Vaga> GetVagaByDescricaoAndEmpresa(string descricao_, string empresa_)
        {
            var vagas = await _context.Vagas.ToArrayAsync();
            return vagas.FirstOrDefault(x => x.Descricao == descricao_ && x.Empresa == empresa_);
        }

        /// <summary>
        /// Metodo responsavel por buscar a vaga pelo ID
        /// </summary>
        /// <param name="id">ID da vaga</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Vaga> GetVagaById(int id)
        {
            var vagas = await _context.Vagas.ToArrayAsync();
            return vagas.FirstOrDefault(x => x.ID == id);
        }
    }
}
