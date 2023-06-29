using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Entidades;
using MySqlConnector;

namespace Biblioteca.Models.Repositories
{
    public class ContextDataMySql : IContextData
    {
        private readonly MySqlConnection _mySqlConnector = null;

        public ContextDataMySql(IConnectionManager connectionManager)
        {   
            _mySqlConnector = connectionManager.GetConnection();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AtualizarLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(string id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLivro(string id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarCliente()
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarLivro()
        {
            throw new NotImplementedException();
        }

        public Cliente PesquisarClientePorId(string id)
        {
            throw new NotImplementedException();
        }

        public Livro PesquisarLivroPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
