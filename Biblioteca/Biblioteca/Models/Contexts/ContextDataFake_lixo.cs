using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Entidades;

namespace Biblioteca.Models.Contexts
{
    public class ContextDataFake_lixo : IContextData
    {
        private readonly DbContexto _dbContexto;

        public ContextDataFake_lixo(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AtualizarLivro(Livro livro)
        {
            var objPesquisa = PesquisarLivroPorId(livro.Id);
            _dbContexto.Remove(objPesquisa);
            _dbContexto.SaveChanges();

            objPesquisa.Nome = livro.Nome;
            objPesquisa.Editora = livro.Editora;
            objPesquisa.Autor = livro.Autor;

            CadastrarLivro(objPesquisa);
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(Livro livro)
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

        public void ExcluirCliente(string id)
        {
            throw new NotImplementedException();
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

        public List<Cliente> ListarCliente()
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarLivro()
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

        public Cliente PesquisarClientePorId(string id)
        {
            throw new NotImplementedException();
        }

        public Livro PesquisarLivroPorId(string id)
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
