using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryEscenas
    {
        private XDocument document;
        private string path;

        public RepositoryEscenas()
        {
            this.path = PathProvider.MapPath("escenaspeliculas.xml", Folders.Documents);
            document = XDocument.Load(path);
        }

        public List<Escena> GetEscenasPeliculas(int idpelicula)
        {
            var consulta = from datos in this.document.Descendants("escena")
                           where datos.Attribute("idpelicula").Value
                           == idpelicula.ToString()
                           select datos;
            List<Escena> listEscenas = new List<Escena>();
            foreach (XElement dato in consulta)
            {
                Escena escena = new Escena
                {
                    IdPelicula = int.Parse(dato.Attribute("idpelicula").Value),
                    Titulo = dato.Element("tituloescena").Value,
                    Descripcion = dato.Element("descripcion").Value,
                    Imagen = dato.Element("imagen").Value
                };
                listEscenas.Add(escena);
            }
            return listEscenas;
        }

        public Escena GetEscenaPelicula(int idpelicula, int posicion, ref int numeroescenas)
        {
            var consulta = from datos in this.document.Descendants("escena")
                           where datos.Attribute("idpelicula").Value
                           == idpelicula.ToString()
                           select datos;
            List<Escena> listEscenas = new List<Escena>();
            foreach (XElement dato in consulta)
            {
                Escena escena = new Escena
                {
                    IdPelicula = int.Parse(dato.Attribute("idpelicula").Value),
                    Titulo = dato.Element("tituloescena").Value,
                    Descripcion = dato.Element("descripcion").Value,
                    Imagen = dato.Element("imagen").Value
                };
                listEscenas.Add(escena);
            }
            numeroescenas = listEscenas.Count;
            Escena escena1 =
            listEscenas.Skip(posicion).Take(1).FirstOrDefault();
            return escena1;
        }




    }
}
