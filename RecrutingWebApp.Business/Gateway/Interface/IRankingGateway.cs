using RecrutingWebApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingWebApp.Application.Gateway.Interface
{
    public interface IRankingGateway
    {
        Task<List<Ranking>> GetRankingVaga(int idVaga);

        Task<bool> AddRankingVaga(Vaga vaga, Pessoa pessoa);
    }
}
