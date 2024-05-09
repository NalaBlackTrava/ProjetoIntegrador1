using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador.Domain.Entity.Creches;

namespace ProjetoIntegrador.Data.Maps.Creches
{
    public class EventEntityMapping : BaseMap<EventEntity>
    {
        public override void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Users)
                .WithMany(x => x.Events);
        }
    }
}
