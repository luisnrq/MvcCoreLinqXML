﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreLinqXML.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogIn(string usuario, string password)
        {

            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }
    }
}
