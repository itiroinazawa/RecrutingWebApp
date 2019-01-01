using System;
using System.Collections.Generic;
using System.Text;

namespace RecrutingWebApp.Model
{
    public class Ranking
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Profissao { get; set; }
        public String Localizacao { get; set; }
        public int Nivel { get; set; }
        public int Score { get; set; }
        public int IdVaga { get; set; }
    }
}
