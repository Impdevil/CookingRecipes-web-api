using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrazyGrannyCookingRecipes;

namespace CrazyGrannyCookingRecipes.Data
{
    public class CrazyGrannyCookingRecipesContext : DbContext
    {
        public CrazyGrannyCookingRecipesContext (DbContextOptions<CrazyGrannyCookingRecipesContext> options)
            : base(options)
        {
        }

        public DbSet<CrazyGrannyCookingRecipes._recipes> _recipes { get; set; }
    }
}
