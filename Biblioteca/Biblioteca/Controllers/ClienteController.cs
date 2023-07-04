using Biblioteca.Models.Contracts.Services;
using Biblioteca.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                var clientes = _clienteService.Listar();
                return View(clientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome, CPF, EMmail, Fone")] ClienteDto clienteDto)
        {
            try
            {
                _clienteService.Cadastrar(clienteDto);
                return RedirectToAction("List");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var cliente = _clienteService.PesquisarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome, CPF, Email, Fone, StatusClienteId")] ClienteDto clienteDto)
        {
            if (string.IsNullOrEmpty(clienteDto.Id))
            {
                return NotFound();
            }

            try
            {
                _clienteService.Atualizar(clienteDto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult Details(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var cliente = _clienteService.PesquisarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var cliente = _clienteService.PesquisarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete([Bind("Id, Nome, CPF, Email, Fone, StatusClienteId")] ClienteDto clienteDto) { 
            _clienteService.Excluir(clienteDto.Id);
            return RedirectToAction("List");
        }
    }
}
