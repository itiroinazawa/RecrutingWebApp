using RecrutingWebApp.Model;
using RecrutingWebApp.Parser.Base;

namespace RecrutingWebApp.Parser
{
    public class PessoaParser : BaseParser<PessoaViewModel, Pessoa>
    {
        public override Pessoa ParseItem(PessoaViewModel item)
        {
            Pessoa model = new Pessoa
            {
                Nome = item.Nome,
                Profissao = item.Profissao,
                Nivel = item.Nivel,
                Localizacao = item.Localizacao,
                ID = item.ID
            };

            return model;
        }
    }
}
