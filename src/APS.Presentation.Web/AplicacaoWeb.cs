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

            if (usuario != null)
            {
                usuario.EstaLogado = true;
                return usuario;
            }

            var cookie = HttpContext.Current.Response.Cookies.Get(chaveUsuarioLogadoSessao);

            if (cookie != null && cookie.HasKeys)
            {
                usuario = BuscarUsuarioLogin(cookie.Value);
                if (usuario != null)
                {
                    HttpContext.Current.Session[chaveUsuarioLogadoSessao] = usuario;
                    return usuario;
                };
            }

            return new UsuarioViewModel { EstaLogado = false };
        }

        public static void InicializarSistema()
        {
            var usuarioService = InMemory.GetService<IUsuarioAppService>();

            var usuario = usuarioService.BuscarTodos().FirstOrDefault(x => x.Login == nomeUsuario);

            if (usuario != null) return;

            usuarioService.Cadastrar(new UsuarioViewModel { Email = "tes@com.com", Id = 0, Login = nomeUsuario, Nome = "Luis Cesar", Senha = "123", TipoUsuario = eTipoUsuario.Administrador });
        }

        public static void LogarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var cookie = new HttpCookie(chaveUsuarioLogadoSessao)
            {
                Expires = DateTime.Now.AddDays(3)
            };

            cookie.Value = usuarioViewModel.Login;

            HttpContext.Current.Response.Cookies.Add(cookie);

            HttpContext.Current.Session.Add(chaveUsuarioLogadoSessao, usuarioViewModel);            
        }

        public static void LogOffUsuario()
        {
            HttpContext.Current.Session.Remove(chaveUsuarioLogadoSessao);
            HttpContext.Current.Response.Cookies.Remove(chaveUsuarioLogadoSessao);
        }        
        

        private static UsuarioViewModel BuscarUsuarioLogin(string login)
        {
            var usuarioService = InMemory.GetService<IUsuarioAppService>();

            return usuarioService.BuscarTodos().FirstOrDefault(x => x.Login == nomeUsuario);
        }
    }
}