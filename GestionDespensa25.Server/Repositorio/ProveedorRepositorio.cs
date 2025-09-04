using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Repositorio
{
    public class ProveedorRepositorio : Repositorio<Proveedor>, IProveedorRepositorio
    {
        private readonly Context context;

        public ProveedorRepositorio( Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Proveedor> SelectById(string nom)
        {
            Proveedor? prov = await context.Proveedores
                      .FirstOrDefaultAsync(x => x.Nombre == nom);
           
            return prov;
        }
    }
}
