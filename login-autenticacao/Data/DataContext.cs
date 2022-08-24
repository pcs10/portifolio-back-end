using login_autenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace login_autenticacao.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
