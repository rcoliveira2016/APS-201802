using APS.Application.Interfaces;
using APS.Domain.Core.Models.Usurios;
using APS.Infra.CrossCutting.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsuarioViewModel = APS.Application.ViewModel.Usuario.CadastroViewModel;

namespace APS.Presentation.Web
{
    public static class AplicacaoWeb
    {

        const string nomeUsuario = "***";
        const string chaveUsuarioLogadoSessao = "UsuarioLogado";
        const string chaveValorLoginUsuario = "LoginUsuario";

        public static UsuarioViewModel UsuarioLogado { get => ObterUsuarioLogado();  }

        private static UsuarioViewModel ObterUsuarioLogado()
        {
            var usuario = HttpContext.Current.Session[chaveUsuarioLogadoSessao] as UsuarioViewModel;

            if (usuario != null) return usuario;

            var cookie = HttpContext.Current.Response.Cookies.Get(chaveUsuarioLogadoSessao);

            if (cookie != null && cookie.HasKeys)
            {
                usuario = BuscarUsuarioLogin(cookie.Values[chaveValorLoginUsuario]);
                if(usuario != null) return usuario;
            }

            return new UsuarioViewModel { EstaLogado = false };
        }

        public static void InicializarSistema()
        {
            var usuarioService = InMemory.GetService<IUsuarioAppService>();

            var usuario = usuarioService.BuscarTodos().FirstOrDefault(x => x.Login == nomeUsuario);

            if (usuario != null) return;

            usuarioService.Cadastrar(new UsuarioViewModel { Email = "", Id = 0, Login = nomeUsuario, Nome = "Luis Cesar", Senha = "123", TipoUsuario = eTipoUsuario.Administrador });
        }

        public static void LogarUsuario(UsuarioViewModel usuarioViewModel)
        {
            HttpContext.Current.Session.Add(chaveUsuarioLogadoSessao, usuarioViewModel);
            SetarCookie(usuarioViewModel);
        }

        public static void LogOffUsuario()
        {
            HttpContext.Current.Session.Remove(chaveUsuarioLogadoSessao);
            HttpContext.Current.Response.Cookies.Remove(chaveUsuarioLogadoSessao);
        }        

        public static void SetarCookie(UsuarioViewModel usuarioViewModel)
        {
            var cookie = new HttpCookie(chaveUsuarioLogadoSessao);
            cookie.Expires = DateTime.Now.AddDays(3);
            cookie.Values[chaveValorLoginUsuario] = usuarioViewModel.Login;

            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        private static UsuarioViewModel BuscarUsuarioLogin(string login)
        {
            var usuarioService = InMemory.GetService<IUsuarioAppService>();

            return usuarioService.BuscarTodos().FirstOrDefault(x => x.Login == nomeUsuario);
        }
    }
}