using GestionDespensa25.BD.Data.Entity;

namespace GestionDespensa25.Server.Repositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        Task<Producto?> SelectByNombre(string nombre);
    }
}
