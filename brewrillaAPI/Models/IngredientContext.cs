using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brewrillaAPI.Models
{
    public class IngredientContext : DbContext
    {
        public IngredientContext(DbContextOptions<IngredientContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient>  Ingredients { get; set; }

    }
}
