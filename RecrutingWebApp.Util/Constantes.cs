using System;
using System.Collections.Generic;
using System.Text;

namespace RecrutingWebApp.Util
{
    public static class Constantes
    {
        public static class Messages
        {
            public const string SUCCESS_MESSAGE_POST_CANDIDATURA = "Candidatura realizada com sucesso.";
            public const string ERROR_MESSAGE_POST_409_CANDIDATURA = "Essa pessoa ja se candidatou a essa vaga";

            public const string SUCCESS_MESSAGE_POST_VAGAS = "Vaga cadastrada com sucesso.";
            public const string ERROR_MESSAGE_POST_409_VAGAS = "Essa vaga já existe para esta empresa na base de dados";

            public const string SUCCESS_MESSAGE_POST_PESSOA = "Pessoa cadastrada com sucesso.";
            public const string ERROR_MESSAGE_POST_409_PESSOA = "Essa pessoa já existe na base de dados";

            public const string ERROR_MESSAGE_POST_500 = "Ocorreu um erro ao executar. Contate o administrador.";
        }
    }
}
