using Biblioteca.Models.Entidades;
using Biblioteca.Models.Enums;
using System;

namespace Biblioteca.Models.Repositories
{
    public class SqlManager
    {
        public static string GetSql(TSql tsql) {
            var sql = "";

            switch (tsql)
            {
                case TSql.CADASTRAR_LIVRO:
                    sql = "INSERT INTO livrodtos (Id, Nome, Autor, Editora, StatusLivroId) VALUES(CAST(@Id AS CHAR(36)), @Nome, @Autor, @Editora, @StatusLivroId)";
                    break;
                case TSql.LISTAR_LIVRO:
                    sql = "SELECT CAST(Id AS CHAR(36)) as Id, Nome, Autor, Editora FROM livrodtos ORDER BY Nome";
                    break;
                case TSql.PESQUISAR_LIVRO:
                    sql = "SELECT Id, Nome, Autor, Editora FROM livrodtos WHERE Id = CAST(@Id AS CHAR(36))";
                    break;
                case TSql.ATUALIZAR_LIVRO:
                    sql = "UPDATE livrodtos SET Nome=@Nome, Autor=@Autor, Editora=@Editora WHERE Id=@Id";
                    break;
                case TSql.EXCLUIR_LIVRO:
                    sql = "DELETE FROM livrodtos WHERE Id = CAST(@Id AS CHAR(36))";
                    break;

                case TSql.CADASTRAR_CLIENTE:
                    sql = "INSERT INTO cliente (id, nome, cpf, email, fone, statusClienteId) VALUES(CAST(@Id AS CHAR(36)), @Nome, @cpf, @email, @fone, @statusClienteId)";
                    break;
                case TSql.LISTAR_CLIENTE:
                    sql = "SELECT CAST(Id AS CHAR(36)) as Id, nome, cpf, email, fone, statusClienteId FROM cliente";
                    break;
                case TSql.PESQUISAR_CLIENTE:
                    sql = "SELECT Id, nome, cpf, email, fone, statusClienteId FROM cliente WHERE Id = CAST(@Id AS CHAR(36))";                    
                    break;
                case TSql.ATUALIZAR_CLIENTE:
                    sql = "UPDATE cliente SET nome=@nome, cpf=@cpf, email=@email, fone=@fone WHERE Id=@Id";
                    break;
                case TSql.EXCLUIR_CLIENTE:
                    sql = "DELETE FROM cliente WHERE Id = CAST(@Id AS CHAR(36))";
                    break;
            }

            return sql;
        }
    }
}
