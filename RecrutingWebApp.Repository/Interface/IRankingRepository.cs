using RecrutingWebApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecrutingWebApp.Repository.Interface
{
    public interface IRankingRepository
    {
        Task<List<Ranking>> GetRankingVaga(int idVaga);

        Task<bool> AddRankingVaga(Ranking model);
    }
}
