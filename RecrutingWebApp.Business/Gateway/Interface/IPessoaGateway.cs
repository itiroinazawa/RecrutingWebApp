using RecrutingWebApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecrutingWebApp.Application.Gateway.Interface
{
    public interface IPessoaGateway
    {
        Task<bool> CreatePessoa(Pessoa model);

        Task<Pessoa> GetPessoaById(int id);
    }
}
