using RecrutingWebApp.Model;
using RecrutingWebApp.Parser.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutingWebApp.Parser
{
    public class RankingParser : BaseParser<Ranking, RankingViewModel>
    {
        public override RankingViewModel ParseItem(Ranking item)
        {
            RankingViewModel model = new RankingViewModel
            {
                Localizacao = item.Localizacao,
                Nivel = item.Nivel,
                Nome = item.Nome,
                Profissao = item.Profissao,
                Score = item.Score
            };

            return model;
        }
    }
}
