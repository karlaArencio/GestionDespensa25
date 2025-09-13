using GestionDespensa25.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace GestionDespensa25.Server.Repositorio
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        Task<Categoria?> SelectByNom(string nombre);
    }
}
