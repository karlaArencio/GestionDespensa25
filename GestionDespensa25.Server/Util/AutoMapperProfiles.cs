using AutoMapper;
using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Shared.DTO;

namespace GestionDespensa25.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Modulos crear ida y vuelta
            CreateMap<CrearCategoriaDTO, Categoria>();
            CreateMap<Categoria, CrearCategoriaDTO>();

            CreateMap<CrearProveedorDTO, Proveedor>();
            CreateMap<Proveedor, CrearProveedorDTO>();
         
            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<Usuario, CrearUsuarioDTO>();

            CreateMap<CrearProductoDTO, Producto>();
            CreateMap<Producto, CrearProductoDTO>();

            CreateMap<CrearClienteDTO, Cliente>();
            CreateMap<Cliente, CrearClienteDTO>();
        }
    }
}
