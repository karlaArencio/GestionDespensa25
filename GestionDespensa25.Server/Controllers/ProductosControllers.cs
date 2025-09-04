using AutoMapper;
using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Server.Repositorio;
using GestionDespensa25.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosControllers : ControllerBase
    {
        private readonly IProductoRepositorio repositorio;
        private readonly IMapper mapper;

        public ProductosControllers(IProductoRepositorio repositorio,
                                     IMapper mapper)
        {
          
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet] //api/Productos
        public async Task<ActionResult<List<Producto>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]//api/Productos/existe/2
        public async Task<ActionResult<Producto>> Get(int id)
        {
            Producto? producto = await repositorio.SelectById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpGet("GetByNombre{nombre}")]//api/Productos/por-nombre/coca
        public async Task<ActionResult<Producto>> GetByNombre(string nombre) 
        {
            //Buscamos el producto por su nombre
            Producto? producto = await repositorio.SelectByNombre(nombre);
            if (producto == null)
            {
                return NotFound($"No se encontro el producto con nombre:{nombre}");
            }
            return producto;
        }

        [HttpGet("existe/{id:int}")] //api/Productos/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]//api/Productos
        public async Task<ActionResult<int>> Post(CrearProductoDTO entidadDTO)
        {
            try
            {

                Producto entidad = mapper.Map<Producto>(entidadDTO);
             
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Productos/1
        public async Task<ActionResult> Put(int id, [FromBody] Producto entidad)

        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var prod = await repositorio.SelectById(id);

            if (prod == null)
            {
                return NotFound("No existe el producto.");
            }
            prod.Nombre = entidad.Nombre;
            prod.StockActual = entidad.StockActual;
            prod.StockMinimo = entidad.StockMinimo;
            prod.PrecioCosto = entidad.PrecioCosto;
            prod.PorcentajeGanancia = entidad.PorcentajeGanancia;
            prod.PrecioVenta = entidad.PrecioVenta;
            prod.Estado = entidad.Estado;


            try
            {
                await repositorio.Update(id, prod);
                
                return Ok(prod);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//api/Productos/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El producto {id} no existe.");
            }
            if (await repositorio.Delete(id))
            {
                return Ok();
            }

            else
            {
                return BadRequest();
            }
                
        }

    }
}
