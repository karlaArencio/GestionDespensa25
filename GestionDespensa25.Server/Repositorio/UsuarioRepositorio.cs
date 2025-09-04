using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;

namespace GestionDespensa25.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Context context;

        public UsuarioRepositorio( Context context) : base(context)
        {
            this.context = context;
        }
    }
}
