using Microsoft.EntityFrameworkCore;
using RecrutingWebApp.Model;

namespace RecrutingWebApp.Util.Context
{
    /// <summary>
    /// API context criado para adicionar os registros das informacoes em memoria
    /// </summary>
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            
        }

        public DbSet<Candidatura> Candidaturas { get; set; }

        public DbSet<Vaga> Vagas { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Ranking> RankingVagas { get; set; }
    }
}
