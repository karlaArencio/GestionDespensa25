using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GestionDespensa25.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Context context;

        public UsuarioRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<Usuario> SelectByNom(string nombre)
        {
             Usuario? nom = await context.Usuarios
                      .FirstOrDefaultAsync(x => x.NombreUsuario == nombre);
            return nom;  
        }
            
            
        
    }
}
