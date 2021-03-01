using BrandChallenge.Brands;
using BrandChallenge.Challenges;
using BrandChallenge.Tricks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandChallenge.EntityFrameworkCore.Mapping
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(128);
        }
    }
}
