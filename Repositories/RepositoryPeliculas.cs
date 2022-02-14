using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryPeliculas
    {
        private XDocument document;
        private string path;

        public RepositoryPeliculas()
        {
            this.path = PathProvider.MapPath("peliculas.xml", Folders.Documents);
            document = XDocument.Load(path);
        }

        public List<Pelicula> GetPeliculas()
        {
            var consulta = from datos in this.document.Descendants("pelicula")
                           select datos;
            List<Pelicula> listPeliculas = new List<Pelicula>();
            foreach(XElement dato in consulta)
            {
                Pelicula pelicula = new Pelicula();
                pelicula.IdPelicula = int.Parse(dato.Attribute("idpelicula").Value);
                pelicula.Titulo = dato.Element("titulo").Value;
                pelicula.TituloOriginal = dato.Element("titulooriginal").Value;
                pelicula.Descripcion = dato.Element("descripcion").Value;
                pelicula.Poster = dato.Element("poster").Value;
                listPeliculas.Add(pelicula);
            }
            return listPeliculas;
        }

    }
}
