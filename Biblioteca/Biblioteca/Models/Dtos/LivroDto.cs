using Biblioteca.Models.Entidades;
using Biblioteca.Models.Enums;

namespace Biblioteca.Models.Dtos
{
    public class LivroDto : EntidadeBase
    {
        //public string Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int StatusLivroId { get; set; }
        public string Status { get; set; }


        public LivroDto()
        {
        }

        public Livro ConverterParaEntidade() { 
            return new Livro { 
                Id = Id,
                Nome = Nome,    
                Autor = Autor,
                Editora = Editora,
                StatusLivro = GerenciadorDeStatus.PesquisarStatusDoLivroPeloId(StatusLivroId)
            };
        }
    }
}
