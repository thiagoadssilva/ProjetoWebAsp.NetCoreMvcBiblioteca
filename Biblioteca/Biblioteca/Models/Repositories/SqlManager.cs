using Biblioteca.Models.Enums;

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
            }

            return sql;
        }
    }
}
