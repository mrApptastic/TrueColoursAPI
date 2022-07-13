using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrueColoursAPI.Models;

namespace TrueColoursAPI.Data
{
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            { }

        public DbSet<Colour> TrueColours { get; set; }        
        public DbSet<ColourType> TrueTypes { get; set; }
    }
}   

