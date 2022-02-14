using MvcCoreLinqXML.Models;
using MvcCoreLinqXML.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcCoreLinqXML.Repositories
{
    public class RepositoryUsuarios
    {
        private XDocument document;
        private string path;

        public RepositoryUsuarios()
        {
            this.path = PathProvider.MapPath("ClientesID.xml", Folders.Documents);
            document = XDocument.Load(path);
        }

        public Usuario GetUsuario(string username,string password)
        {
            var consulta = from datos in this.document.Descendants("curso")
                           where 
                           select datos;
        }
    }
}
