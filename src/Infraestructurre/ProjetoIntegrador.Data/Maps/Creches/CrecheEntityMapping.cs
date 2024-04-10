using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Data.Maps.Creches
{
    public class CrecheEntityMapping : BaseMap<CrecheEntity>
    {
        public override void Configure(EntityTypeBuilder<CrecheEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Administradores).
                WithMany(x => x.Creches);

            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.Creche)
                .HasForeignKey(x => x.CrecheId);

            builder.HasMany(x => x.Events)
                .WithOne(x => x.Creche)
                .HasForeignKey(x => x.CrecheId);
        }
    }
}
