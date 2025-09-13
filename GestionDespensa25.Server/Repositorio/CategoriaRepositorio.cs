using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly Context context;

        public CategoriaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<Categoria?>SelectByNom(string nombre)
        {
            return await context.Categorias.AsNoTracking()
                .FirstOrDefaultAsync(x => x.NombreCategoria == nombre);
            
        }

        //Task<ActionResult<Categoria?>> ICategoriaRepositorio.SelectByNom(string nombre)
        //{
        //    throw new NotImplementedException();
        //}
    }
}                                              
