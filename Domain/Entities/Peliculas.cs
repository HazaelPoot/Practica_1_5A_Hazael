using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculasHazaelApi.Domain.Entities
{
    public class Peliculas
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public double Puntuacion { get; set; }
        public double Rating { get; set; }
        public int Publicacion { get; set; }

    }
}