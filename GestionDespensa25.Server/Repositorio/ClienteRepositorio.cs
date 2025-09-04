using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly Context context;

        public ClienteRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<Cliente?> SelectByApe(string ape)
        {
            return await context.Clientes.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Apellido == ape);

        }

    }
}
