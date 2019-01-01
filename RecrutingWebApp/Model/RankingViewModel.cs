using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutingWebApp.Model
{
    public class RankingViewModel
    {
        public String Nome { get; set; }
        public String Profissao { get; set; }
        public String Localizacao { get; set; }
        public int Nivel { get; set; }
        public int Score { get; set; }
    }
}
