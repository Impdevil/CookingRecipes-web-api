using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyGrannyCookingRecipes
{
    public class _recipes
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string ingredients { get; set; }
        public string instructions { get; set; }
    }
}
