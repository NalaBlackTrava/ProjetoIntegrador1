using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegrador.Domain.Entity.User;

namespace ProjetoIntegrador.Data.Maps.User
{
    public class UserEntityMapping : BaseMap<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Addresses)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
