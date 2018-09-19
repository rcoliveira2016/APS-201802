using APS.Domain.Interfaces.Repository.Usuario;
using APS.Infra.Data.Context.Repository.EntityFramework.Usuario.Common;
using APS.Infra.Data.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioModel = APS.Domain.Models.Usurios.Usuario;

namespace APS.Infra.Data.Context.Repository.EntityFramework.Usuario
{
    public sealed class UsuarioRepository: Repository<UsuarioModel> ,IUsuarioRepository
    {


        public UsuarioRepository(IDbContext dbContext):base(dbContext)
        {
        }
       
        
    }
}
