using BookApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Configuration.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Romance"
                },
                new Category
                {
                    Id = 2,
                    Name = "Thriller"
                },
                new Category
                {
                    Id = 3,
                    Name = "Horror"
                },
                new Category
                {
                    Id = 4,
                    Name = "Fantasy"
                },
                new Category
                {
                    Id = 5,
                    Name = "Adventure"
                });
        }
    }
}
