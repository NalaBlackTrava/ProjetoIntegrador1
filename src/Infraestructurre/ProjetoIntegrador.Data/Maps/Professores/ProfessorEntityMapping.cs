using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador.Domain.Entity.Professores;

namespace ProjetoIntegrador.Data.Maps.Professores
{
    public class ProfessorEntityMapping : BaseMap<ProfessorEntity>
    {
        public override void Configure(EntityTypeBuilder<ProfessorEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Address)
                .WithMany(x => x.Professores);
        }
    }
}
