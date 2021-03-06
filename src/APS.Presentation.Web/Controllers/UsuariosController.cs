﻿using APS.Application.Interfaces;
using APS.Application.ViewModel.Usuario;
using APS.Domain.Core.Exceptions;
using APS.Presentation.Web.Helpers.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace APS.Presentation.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioAppService usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}