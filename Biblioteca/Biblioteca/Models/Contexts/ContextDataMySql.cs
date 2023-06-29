using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;
using Biblioteca.Models.Entidades;
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

        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.ATUALIZAR_CLIENTE);
                var command = new MySqlCommand(query, _mySqlConnector);

                command.Parameters.Add("@Id", MySqlDbType.VarString).Value = cliente.Id;
                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@Fone", MySqlDbType.VarChar).Value = cliente.Fone;
                //command.Parameters.Add("@StatusLivroId", MySqlDbType.VarChar).Value = livro.StatusLivro;

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

        public void AtualizarLivro(Livro livro)
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
                //command.Parameters.Add("@StatusLivroId", MySqlDbType.VarChar).Value = livro.StatusLivro;

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

        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.CADASTRAR_CLIENTE);
                var command = new MySqlCommand(query, _mySqlConnector);

                command.Parameters.Add("@Id", MySqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@Fone", MySqlDbType.VarChar).Value = cliente.Fone;
                command.Parameters.Add("@Cpf", MySqlDbType.VarChar).Value = cliente.CPF;
                command.Parameters.Add("@StatusClienteId", MySqlDbType.Int64).Value = cliente.StatusCliente.GetHashCode();

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

        public void CadastrarLivro(Livro livro)
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
                command.Parameters.Add("@StatusLivroId", MySqlDbType.Int64).Value = livro.StatusLivro.GetHashCode();

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

        public void ExcluirCliente(string id)
        {
            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.EXCLUIR_CLIENTE);
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

        public List<Cliente> ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {

                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.LISTAR_CLIENTE);
                var command = new MySqlCommand(query, _mySqlConnector);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            Id = reader["Id"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            CPF = reader["CPF"].ToString(),
                            Email = reader["Email"].ToString(),
                            Fone = reader["Fone"].ToString(),
                            StatusClienteId = reader["StatusClienteId"].GetHashCode()
                        };

                        clientes.Add(cliente);
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

            return clientes;
        }

        public List<Livro> ListarLivro()
        {
            List<Livro> livros = new List<Livro>();
            try
            {

                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);
                var command = new MySqlCommand(query, _mySqlConnector);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var livro = new Livro
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

        public Cliente PesquisarClientePorId(string id)
        {
            Cliente cliente = null;

            try
            {
                _mySqlConnector.Open();

                var query = SqlManager.GetSql(TSql.PESQUISAR_CLIENTE);
                var command = new MySqlCommand(query, _mySqlConnector);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            Id = reader["Id"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            CPF = reader["CPF"].ToString(),
                            Email = reader["Email"].ToString(),
                            Fone = reader["Fone"].ToString(),
                            StatusClienteId = reader["StatusClienteId"].GetHashCode()
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

            return cliente;
        }

        public Livro PesquisarLivroPorId(string id)
        {
            Livro livro = null;

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
                        livro = new Livro
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
