using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeliculasHazaelApi.Domain.Entities;

namespace PeliculasHazaelApi.Infraestructure.Data
{
       public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Peliculas> PELICULAS { get; set; } 
    }
}