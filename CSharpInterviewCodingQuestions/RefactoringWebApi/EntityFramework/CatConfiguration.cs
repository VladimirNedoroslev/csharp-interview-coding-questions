using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactoringWebApi.Models;

namespace RefactoringWebApi.EntityFramework;

public class CatConfiguration : IEntityTypeConfiguration<Cat>
{
    public void Configure(EntityTypeBuilder<Cat> builder)
    {
        builder.ToTable("cats");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasDefaultValue(new DateTime());

        builder.HasOne(x => x.User)
            .WithMany(x => x.Cats)
            .HasForeignKey(x => x.UserId);
    }
}