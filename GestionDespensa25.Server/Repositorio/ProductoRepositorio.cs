using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context context;

        public ProductoRepositorio( Context context ) : base(context)
        {
            this.context = context;
        }
        public async Task<Producto?> SelectByNombre(string nombre)
        {
            return await context.Set<Producto>()
                           .AsNoTracking()
                .FirstOrDefaultAsync(x=> x.Nombre== nombre);
        }
    }
}
