using Microsoft.EntityFrameworkCore;
using RecrutingWebApp.Util.Context;
using RecrutingWebApp.Model;
using RecrutingWebApp.Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApiContext _context;

        public PessoaRepository(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo responsavel por buscar o ID disponivel
        /// </summary>
        /// <returns>ID disponivel para insercao</returns>
        private async Task<int> GetLastId()
        {
            var pessoas = await _context.Pessoas.ToArrayAsync();

            if (pessoas == null || pessoas.Count() == 0)
            {
                return 1;
            }
            else
            {
                var lastItem = pessoas.OrderByDescending(x => x.ID).FirstOrDefault();
                return lastItem.ID + 1;
            }
        }

        /// <summary>
        /// Metodo responsavel por cadastrar o candidato
        /// </summary>
        /// <param name="model">Informacoes do candidato</param>
        /// <returns>Status do cadastro</returns>
        public async Task<bool> CreatePessoa(Pessoa model)
        {
            try
            {
                model.ID = await GetLastId();
                _context.Pessoas.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo responsavel por buscar o candidato pelo nome
        /// </summary>
        /// <param name="name_">Nome do candidato</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Pessoa> GetPessoaByName(string name_)
        {
            var pessoas = await _context.Pessoas.ToArrayAsync();
            return pessoas.FirstOrDefault(x => x.Nome == name_);
        }

        /// <summary>
        /// Metodo responsavel por buscar o candidato por ID
        /// </summary>
        /// <param name="id">ID do candidato</param>
        /// <returns>Objeto buscado</returns>
        public async Task<Pessoa> GetPessoaById(int id)
        {
            var pessoas = await _context.Pessoas.ToArrayAsync();
            return pessoas.FirstOrDefault(x => x.ID == id);
        }
    }
}
