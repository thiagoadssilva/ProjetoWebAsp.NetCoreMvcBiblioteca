using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Contexts
{
    public class ContextDataFake_lixo : IContextData
    {
        private readonly DbContexto _dbContexto;

        public ContextDataFake_lixo(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public void AtualizarLivro(LivroDto livro)
        {
            var objPesquisa = PesquisarLivroPorId(livro.Id);
            _dbContexto.Remove(objPesquisa);
            _dbContexto.SaveChanges();

            objPesquisa.Nome = livro.Nome;
            objPesquisa.Editora = livro.Editora;
            objPesquisa.Autor = livro.Autor;

            CadastrarLivro(objPesquisa);
        }

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                _dbContexto.Add(livro);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(id);
                _dbContexto.Remove(objPesquisa);
                _dbContexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDto> ListarLivro()
        {
            try
            {
                return _dbContexto.livroDtos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            try
            {
                return _dbContexto.livroDtos.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
