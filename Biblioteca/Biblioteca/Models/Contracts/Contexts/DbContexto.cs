using Biblioteca.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models.Contracts.Contexts
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {

        }

        public DbSet<LivroDto> livroDtos { get; set; }
    }
}
