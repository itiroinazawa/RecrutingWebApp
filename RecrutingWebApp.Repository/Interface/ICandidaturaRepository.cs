using RecrutingWebApp.Model;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository.Interface
{
    public interface ICandidaturaRepository
    {
        Task<Candidatura> GetCandidaturaByPessoaAndVaga(int idPessoa, int idVaga);
        Task<bool> RegisterCandidatura(Candidatura model);
    }
}
