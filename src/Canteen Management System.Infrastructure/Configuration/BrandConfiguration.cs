using Canteen_Management_System.Core.Aggregates.BrandAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canteen_Management_System.Infrastructure.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                  .Property(n => n.Name)
                  .IsRequired();

            builder
                 .OwnsOne(o => o.Address,
                          a =>
                          {
                              a.WithOwner();

                              a.Property(a => a.Street)
                                   .HasMaxLength(180)
                                   .IsRequired();

                              a.Property(a => a.State)
                                   .HasMaxLength(60);

                              a.Property(a => a.Country)
                                  .HasMaxLength(90)
                                  .IsRequired();

                              a.Property(a => a.City)
                                  .HasMaxLength(100)
                                  .IsRequired();

                              a.Property(a => a.ZipCode)
                                  .HasMaxLength(100)
                                  .IsRequired();
                          }

                 );

            builder.HasMany(x => x.Products)
                   .WithOne();
        }
    }
}
