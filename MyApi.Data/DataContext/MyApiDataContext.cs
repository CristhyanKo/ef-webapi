using MyApi.Data.Mappings;
using MyApi.Domain.Model;
using System.Data.Entity;

namespace MyApi.Data.DataContext
{
    public class MyApiDataContext : DbContext
    {
        public MyApiDataContext() : base("MyApiConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AtividadeMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new SituacaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
