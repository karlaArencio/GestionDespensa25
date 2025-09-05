using GestionDespensa25.BD.Data.Entity;

namespace GestionDespensa25.Server.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario?> SelectByNom(string nombre);
    }
}
