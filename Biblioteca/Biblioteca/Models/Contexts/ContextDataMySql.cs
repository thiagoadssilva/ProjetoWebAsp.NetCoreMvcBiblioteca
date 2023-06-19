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
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.ATUALIZAR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);

                command.Parameters.Add("@Id", MySqlDbType.VarString).Value = livro.Id;
                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@Autor", MySqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@Editora", MySqlDbType.VarChar).Value = livro.Editora;

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

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);

                command.Parameters.Add("@Id", MySqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@Autor", MySqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@Editora", MySqlDbType.VarChar).Value = livro.Editora;

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
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);

                command.Parameters.Add("@Id", MySqlDbType.VarString).Value = id;

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
            LivroDto livro = null;

            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.PESQUISAR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        livro = new LivroDto
                        {
                            Id = reader["Id"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Autor = reader["Autor"].ToString(),
                            Editora = reader["Editora"].ToString()
                        };
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

            return livro;
        }
    }
}
