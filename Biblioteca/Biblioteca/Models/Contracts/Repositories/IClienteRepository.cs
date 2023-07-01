using Biblioteca.Models.Entidades;

namespace Biblioteca.Models.Contracts.Repositories
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        List<Cliente> Listar();
        Cliente PesquisarPorId(string id);
        void Atualizar(Cliente cliente);
        void Excluir(string id);
    }
}
