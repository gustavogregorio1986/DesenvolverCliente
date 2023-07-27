﻿using ProjetoDesenvolvido.Models;
using System.Collections.Generic;

namespace ProjetoDesenvolvido.Repositorio.Interface
{
    public interface IClienteRepositorio
    {
        ClienteModel Adicionar(ClienteModel cliente);

        List<ClienteModel> ListarTodos();

        ClienteModel ListarPorId(int id);

    }
}
