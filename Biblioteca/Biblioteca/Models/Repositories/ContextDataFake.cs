using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Repositories
{
    public static class ContextDataFake // Static = Classe não vai ser instanciada
    {
        public static List<LivroDto> Livros;

        static ContextDataFake()
        {
            Livros = new List<LivroDto>();
            InitializeData();
        }

        private static void InitializeData()
        {
            var livro = new LivroDto("Livro 01", "Autor 01", "Editora 01");
            Livros.Add(livro);

            livro = new LivroDto("Livro 02", "Autor 02", "Editora 02");
            Livros.Add(livro);

            livro = new LivroDto("Livro 03", "Autor 03", "Editora 03");
            Livros.Add(livro);

            livro = new LivroDto("Livro 03", "Autor 03", "Editora 03");
            Livros.Add(livro);
        }
    }
}
