using Biblioteca.Models.Dtos;
using Biblioteca.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.Contracts.Contexts
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        public DbSet<Livro> livroDtos { get; set; }

        public DbSet<Biblioteca.Models.Dtos.ClienteDto>? ClienteDto { get; set; }
    }
}
