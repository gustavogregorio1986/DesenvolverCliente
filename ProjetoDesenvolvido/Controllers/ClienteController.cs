using Microsoft.AspNetCore.Mvc;
using ProjetoDesenvolvido.Models;
using ProjetoDesenvolvido.Repositorio.Interface;
using System.Collections.Generic;

namespace ProjetoDesenvolvido.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienetRepositorio;

        public ClienteController(IClienteRepositorio clienetRepositorio)
        {
            _clienetRepositorio = clienetRepositorio;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _clienetRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Consultar");
                }

                return View(cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, cliente não pode ser cadastrados, tnte novamente, erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }
        }

        public IActionResult Consultar()
        {
            List<ClienteModel> listaCliente = _clienetRepositorio.ListarTodos();
            return View(listaCliente);
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienetRepositorio.ListarPorId(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienetRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Consultar");
                }

                return View(cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, cliente não pode ser editado, tènte novamente, erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }

            return View("Editar", cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienetRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _clienetRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Não foi possivel apagar o cliente";
                }

                return RedirectToAction("Consultar");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, cliente não pode ser apagado, tènte novamente, erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }
        }
    }
}
