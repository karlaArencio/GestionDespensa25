using GestionDespensa25.BD.Data.Entity;

namespace GestionDespensa25.Server.Repositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<Cliente?> SelectByApe(string ape);
    }
}
