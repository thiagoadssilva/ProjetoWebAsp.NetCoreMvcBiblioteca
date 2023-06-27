using Biblioteca.Models.Entidades;

namespace Biblioteca.Models.Contracts.Contexts
{
    public interface IContextData
    {
        void CadastrarLivro(Livro livro);
        List<Livro> ListarLivro();
        Livro PesquisarLivroPorId(string id);
        void AtualizarLivro(Livro livro);
        void ExcluirLivro(string id);

    }
}
