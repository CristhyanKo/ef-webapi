using MyApi.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace MyApi.Data.Mappings
{
    public class SituacaoMap : EntityTypeConfiguration<Situacao>
    {
        public SituacaoMap()
        {
            ToTable(nameof(Situacao));
            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired();
        }
    }
}
