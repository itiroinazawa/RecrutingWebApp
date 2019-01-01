using RecrutingWebApp.Model;
using RecrutingWebApp.Parser.Base;

namespace RecrutingWebApp.Parser
{
    public class VagaParser : BaseParser<VagaViewModel, Vaga>
    {
        public override Vaga ParseItem(VagaViewModel item)
        {
            Vaga model = new Vaga
            {
                Descricao = item.Descricao,
                Empresa = item.Empresa,
                ID = item.ID,
                Localizacao = item.Localizacao,
                Nivel = item.Nivel,
                Titulo = item.Titulo
            };

            return model;
        }
    }
}
