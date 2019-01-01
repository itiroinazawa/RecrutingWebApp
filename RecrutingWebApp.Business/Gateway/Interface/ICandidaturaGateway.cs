using RecrutingWebApp.Model;
using System.Threading.Tasks;

namespace RecrutingWebApp.Application.Gateway.Interface
{
    public interface ICandidaturaGateway
    {
        Task<Candidatura> GetCandidaturaByPessoaAndVaga(int idPessoa, int idVaga);
        Task<bool> RegisterCandidatura(Candidatura model);
    }
}
