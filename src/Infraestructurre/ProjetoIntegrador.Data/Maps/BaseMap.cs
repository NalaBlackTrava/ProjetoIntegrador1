using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador.Domain.Entity;

namespace ProjetoIntegrador.Data.Maps
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : DomainEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(GenerateTableName());
            builder.HasKey(x => x.Id);
        }

        public string GenerateTableName()
        {
            return typeof(T).Name.Replace("Entity", "");
        }
    }
}
