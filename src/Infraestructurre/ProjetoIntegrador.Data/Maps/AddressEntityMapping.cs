using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using ProjetoIntegrador.Domain.Entity;

namespace ProjetoIntegrador.Data.Maps
{
    public class AddressEntityMapping : BaseMap<AddressEntity>
    {
        public override void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Images)
                .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<string>>(x)!);
        }
    }
}
