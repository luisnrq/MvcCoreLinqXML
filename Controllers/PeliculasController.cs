using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class PeliculasController : Controller
    {
        private RepositoryPeliculas repoPelis;
        private RepositoryEscenas repoEscenas;

        public PeliculasController(RepositoryPeliculas repoPelis, RepositoryEscenas repoEscenas)
        {
            this.repoPelis = repoPelis;
            this.repoEscenas = repoEscenas;
        }

        public IActionResult Index()
        {
            List<Pelicula> peliculas = this.repoPelis.GetPeliculas();
            return View(peliculas);
        }

        public IActionResult EscenasPeliculas(int idpelicula)
        {
            List<Escena> escenas = this.repoEscenas.GetEscenasPeliculas(idpelicula);
            return View(escenas);
        }

        public IActionResult EscenaPelicula(int idpelicula, int? posicion)
        {
            if (posicion == null)
            {
                posicion = 0;
            }
            int numeroregistros = 0;
            Escena escena =
            this.repoEscenas.GetEscenaPelicula(idpelicula,
            posicion.Value, ref numeroregistros);
            ViewData["REGISTROS"] = "Escena " + (posicion + 1)
            + " de "
            + numeroregistros;

            int siguiente = posicion.Value + 1;
            if (siguiente >= numeroregistros)
            {
                siguiente = 0;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 0)
            {
                anterior = numeroregistros - 1;
            }
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            return View(escena);
        }

        public IActionResult DetailPelicula(int idpelicula)
        {
            List<Pelicula> peliculas = this.repoPelis.GetPeliculas();
            List<Escena> escenas = this.repoEscenas.GetEscenasPeliculas(idpelicula);
            ViewData["ESCENASTOTALES"] = escenas.Count();
            ViewData["IDPELICULA"] = idpelicula;
            return View(peliculas);
        }

        public IActionResult _DetailPelicula(int idpelicula, int? posicion)
        {
            if (posicion == null)
            {
                posicion = 0;
            }
            int numeroregistros = 0;
            Escena escena =
            this.repoEscenas.GetEscenaPelicula(idpelicula,
            posicion.Value, ref numeroregistros);
            ViewData["REGISTROS"] = "Escena " + (posicion + 1)
            + " de "
            + numeroregistros;

            int siguiente = posicion.Value + 1;
            if (siguiente >= numeroregistros)
            {
                siguiente = 0;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 0)
            {
                anterior = numeroregistros - 1;
            }
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            return PartialView("_DetailPelicula",escena);
        }


    }
}
