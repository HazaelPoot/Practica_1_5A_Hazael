using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeliculasHazaelApi.Domain.Entities;
using PeliculasHazaelApi.Infraestructure.Data;

namespace PeliculasHazaelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : Controller
    {
        private readonly AppDbContext context;
        public FilmsController(AppDbContext context)
        {
            this.context = context;
        }

        //GET: MOSTRAR LA LISTA COMPLETA
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(context.PELICULAS.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: MOSTRAR ELEMENTOS DEL ID SOLICITADO
        [HttpGet("{Id}")]
        public ActionResult GeyById(int id)
        {
            try
            {
                var film = context.PELICULAS.FirstOrDefault(a => a.Id == id);
                return Ok(film);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //POST: AGREGAR UN REGISTRO A LA BASE DE DATOS
        [HttpPost]
        public ActionResult Agregar([FromBody]Peliculas peliculas)
        {
            if(peliculas == null)
            return NotFound("Llene los datos Porfavor");
            try
            {
                context.PELICULAS.Add(peliculas);
                context.SaveChanges();
                return Ok("Pelicula Registrada con Exito..!!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //PUT: EDITAR UN REGISTRO
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] Peliculas peliculas)
        {
            try
            {
                if (peliculas.Id == id)
                {
                    context.Entry(peliculas).State = EntityState.Modified;
                    context.SaveChanges();
                    // return CreatedAtRoute("Modificado: ", new { id = peliculas.Id }, peliculas);
                    return Ok("Registro Modificado ");
                }

                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //DELETE: ELIMINAR UN REGISTRO
        [HttpDelete("{Id}")]
        public ActionResult Deleted(int id)
        {
            try
            {
                var peliculas = context.PELICULAS.FirstOrDefault(f => f.Id == id);
                if (peliculas != null)
                {
                    context.PELICULAS.Remove(peliculas);
                    context.SaveChanges();
                    return Ok("Pelicula Eliminada...");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}