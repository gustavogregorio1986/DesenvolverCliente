using ProjetoDesenvolvido.Data;
using ProjetoDesenvolvido.Models;
using ProjetoDesenvolvido.Repositorio.Interface;
using System.Collections.Generic;
using System.Linq;

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

        public ClienteModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> ListarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }
    }
}
