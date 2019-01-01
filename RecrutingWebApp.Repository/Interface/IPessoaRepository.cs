using RecrutingWebApp.Model;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository.Interface
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetPessoaById(int id);

        Task<Pessoa> GetPessoaByName(string name_);

        Task<bool> CreatePessoa(Pessoa model);
    }
}
