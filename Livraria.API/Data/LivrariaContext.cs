/*
Nome: Kaik Persike Maiorquino
Prontuário: CB3029689

Nome: Luiz Gustavo Verissimo Monteiro
Prontuário: CB3030326
*/
using Livraria.Core;
using Microsoft.EntityFrameworkCore;

namespace Livraria.API.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros => Set<Livro>();
    }
}
