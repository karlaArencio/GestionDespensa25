using GestionDespensa25.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GestionDespensa25.Server.Repositorio
{
    public interface IProveedorRepositorio : IRepositorio<Proveedor>
    {
        Task<Proveedor?> SelectById(string id);
    }
}
