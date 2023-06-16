using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;
using Biblioteca.Models.Enums;
using Biblioteca.Models.Repositories;
using MySqlConnector;
using System.Data;

namespace Biblioteca.Models.Contexts
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
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);

                command.Parameters.AddWithValue("@Id", livro.Id);
                command.Parameters.AddWithValue("@Nome", livro.Nome);
                command.Parameters.AddWithValue("@Autor", livro.Autor);
                command.Parameters.AddWithValue("@Editora", livro.Editora);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_mySqlConnector.State == ConnectionState.Open)
                    _mySqlConnector.Close();
            }
        }

        public void ExcluirLivro(string id)
        {
            throw new NotImplementedException();
        }

        public List<LivroDto> ListarLivro()
        {
            List<LivroDto> livros = new List<LivroDto>();
            try
            {

                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var livro = new LivroDto
                        {
                            Id = reader["Id"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Autor = reader["Autor"].ToString(),
                            Editora = reader["Editora"].ToString()
                        };

                        livros.Add(livro);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_mySqlConnector.State == ConnectionState.Open)
                    _mySqlConnector.Close();
            }

            return livros;
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
