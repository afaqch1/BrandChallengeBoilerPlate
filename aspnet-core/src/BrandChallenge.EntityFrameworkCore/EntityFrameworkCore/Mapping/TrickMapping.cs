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
    class TrickMapping : IEntityTypeConfiguration<Trick>
    {
        public void Configure(EntityTypeBuilder<Trick> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Type).IsRequired();
        }
    }
    

}
