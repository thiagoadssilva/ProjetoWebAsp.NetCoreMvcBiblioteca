using Biblioteca.Models.Dtos;
using Biblioteca.Models.Entidades;

namespace Biblioteca.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(Livro livro);
        List<Livro> Listar();
        Livro PesquisarPorId(string id);
        void Atualizar(Livro livro);
        void Excluir(string id);

    }
}
