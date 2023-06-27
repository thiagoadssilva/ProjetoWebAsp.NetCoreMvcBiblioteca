using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Contracts.Services;
using Biblioteca.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            try
            {
                var livros = _service.Listar();
                return View(livros);
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
        public IActionResult Create([Bind("Nome", "Autor", "Editora")] LivroDto livro) {
            try
            {
                //livro.StatusLivroId = 1;
                _service.Cadastrar(livro);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Edit(string? id)
        {
            if (string.IsNullOrEmpty(id)) {
                return NotFound();
            }

            var livro = _service.PesquisarPorId(id);

            if (livro == null){ 
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id","Nome", "Autor", "Editora")] LivroDto livro)
        {
            if (string.IsNullOrEmpty(livro.Id)) {
                return NotFound();
            }

            try
            {
                _service.Atualizar(livro);
                return RedirectToAction("Listar");
            }
            catch(Exception ex)
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

            var livro = _service.PesquisarPorId(id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _service.PesquisarPorId(id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        public IActionResult Delete([Bind("Id", "Nome", "Autor", "Editora")] LivroDto livroDto) {
            _service.Excluir(livroDto.Id);
            return RedirectToAction("Listar");
        }
    }
}
