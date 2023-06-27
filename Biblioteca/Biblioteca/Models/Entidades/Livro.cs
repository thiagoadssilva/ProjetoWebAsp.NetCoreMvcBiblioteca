
using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Entidades
{
    public class Livro : EntidadeBase
    {
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public StatusLivro StatusLivro { get; set; }

        public Livro() : base() { }

        public void Cadastrar()
        {
            StatusLivro = StatusLivro.DISPONIVEL;
        }

        public LivroDto ConverterParaDto()
        {
            return new LivroDto
            {
                Id = Id,
                Nome = Nome,
                Autor = Autor,
                Editora = Editora,
                StatusLivroId = StatusLivro.GetHashCode(),
                Status = StatusLivro.ToString()
            };


        }
    }
}
