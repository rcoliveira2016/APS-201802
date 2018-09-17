using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace APS.Infra.CrossCutting.Session
{

    public static class ControleSessao
    {
        public static T ObterItemSessao<T>(string chave)
        {
            return (T)HttpContext.Current.Session[chave];
        }               

        public static void SetarItemSessao<T>(T value, string chave)
        {
            HttpContext.Current.Session[chave] = value;
        }
    }
    
}
