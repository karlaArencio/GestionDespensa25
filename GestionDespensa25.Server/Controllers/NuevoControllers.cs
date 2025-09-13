using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Server.Repositorio;
using GestionDespensa25.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace GestionDespensa25.Server.Controllers
{
    [ApiController]
    [Route("api/nuevo")]
    public class NuevoControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorioProducto;
        private readonly ICategoriaRepositorio repositorioCateg;

        public NuevoControllers(IProductoRepositorio repositorioProducto,
                                 ICategoriaRepositorio repositorioCateg)
        {
            this.repositorioProducto = repositorioProducto;
            this.repositorioCateg = repositorioCateg;
        }

        [HttpGet("GetProductos")] 
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            return await repositorioProducto.Select();
        }

        [HttpGet("GetCategoria")]
        public async Task<ActionResult<List<Categoria>>> GetCategoria()
        {
            return await repositorioCateg.Select();
        }

        [HttpPost("")]
        public async Task<ActionResult<int>> Post(CrearCateg_ProductoDTO entidadDTO)
        {
            try
            {
                var dim = await repositorioCateg.SelectByNom(entidadDTO.NombreCategoriaCateg);
                if (dim != null)
                {
                    return BadRequest($"EL nombre de la categoria {entidadDTO.NombreCategoriaCateg} ya existe");
                }

                var dim2 = await repositorioProducto.SelectByNombre(entidadDTO.NombreProducto);
                if (dim2 != null)
                {
                    return BadRequest($"EL nombre del producto {entidadDTO.NombreProducto} ya existe");
                }

                //Categoria entCateg =new Categoria();
                //entCateg.NombreCateogria = entidadDTO.NombreCategoriaCateg;

                Categoria entCateg = new Categoria
                {
                    NombreCategoria = entidadDTO.NombreCategoriaCateg,

                };

                int i = await repositorioCateg.Insert(entCateg);
                if (i == 0)
                {
                    BadRequest("No se pudo cargar el tipo de documento");
                }

                Producto entProducto = new Producto
                {
                    Nombre = entidadDTO.NombreProducto,
                    StockActual = int.Parse(entidadDTO.StockActualProducto),
                    StockMinimo = int.Parse(entidadDTO.StockMinimoProducto),
                    PrecioCosto = decimal.Parse(entidadDTO.PrecioCostoProducto),
                    PorcentajeGanancia = decimal.Parse(entidadDTO.PorcentajeGananciaProducto),
                    PrecioVenta = decimal.Parse(entidadDTO.PrecioVentaProducto),
                    Estado = entidadDTO.EstadoProducto.ToLower() == "activo" //si viene string "activo"/"inactivo"
                };

                i = await repositorioProducto.Insert(entProducto);
                if(i==0)
                {
                    BadRequest("No se pudo cargar el producto");
                }
               return i;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
