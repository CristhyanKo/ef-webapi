using MyApi.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace MyApi.Data.Mappings
{
    public class AtividadeMap : EntityTypeConfiguration<Atividade>
    {
        public AtividadeMap()
        {
            ToTable(nameof(Atividade));
            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Titulo).IsRequired().HasMaxLength(60);
            Property(coluna => coluna.Descricao).IsRequired().HasMaxLength(260);

            HasRequired(coluna => coluna.Categoria);
            HasRequired(coluna => coluna.Situacao);
        }
    }
}
