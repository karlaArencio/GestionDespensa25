using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;

namespace GestionDespensa25.Server.Repositorio
{
    public interface IRepositorio<E> where E : class, IEntityBase
    {
        Task<bool> Delete(int id);
        Task<bool> Existe(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E> SelectById(int id);
        //Task<E> SelectByNombre(string nombre);
        Task<bool> Update(int id, E entidad);
    }
}