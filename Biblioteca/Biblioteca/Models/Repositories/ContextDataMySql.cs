using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;
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

        public void AtualizarLivro(LivroDto livro)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(LivroDto livro)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLivro(string id)
        {
            throw new NotImplementedException();
        }

        public List<LivroDto> ListarLivro()
        {
            throw new NotImplementedException();
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
