using ProjetoDesenvolvido.Data;
using ProjetoDesenvolvido.Models;
using ProjetoDesenvolvido.Repositorio.Interface;

namespace ProjetoDesenvolvido.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }
    }
}
