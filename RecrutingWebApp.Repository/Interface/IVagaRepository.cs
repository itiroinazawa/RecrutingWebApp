using RecrutingWebApp.Model;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository.Interface
{
    public interface IVagaRepository
    {
        Task<Vaga> GetVagaById(int id);

        Task<Vaga> GetVagaByDescricaoAndEmpresa(string descricao_, string empresa_);

        Task<bool> CreateVaga(Vaga model);
    }
}
