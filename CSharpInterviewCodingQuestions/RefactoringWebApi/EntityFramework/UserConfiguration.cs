using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactoringWebApi.Models;

namespace RefactoringWebApi.EntityFramework;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Email)
            .IsRequired();

        builder.HasMany(x => x.Cats)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}