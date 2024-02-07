using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationSystem.Domain.Models;

namespace RegistrationSystem.Infrastructure.Data.Map
{
    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);


        }
    }
}
