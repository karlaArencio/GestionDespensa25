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
    [Route("api/Proveedores")]
    public class ProveedoresControllers : ControllerBase
    {
        private readonly IProveedorRepositorio repositorio;
        private readonly IMapper mapper;

        public ProveedoresControllers(IProveedorRepositorio repositorio,
                                      IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet] //api/Proveedores
        public async Task<ActionResult<List<Proveedor>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]//api/Provedores/existe/2
        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            Proveedor? nom = await repositorio.SelectById(id);
            if (nom == null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("GetByNombre")]//api/Proveedores/por-nombre/Lopez
        public async Task<ActionResult<Proveedor?>> GetById(string nombre)
        {
            var prov =await repositorio.SelectById(nombre);
           
            if (prov == null)
            {
                return NotFound($"No existe un proveedor con nombre {nombre}");
            }
            return prov;
        }

        [HttpGet("existe/{id:int}")] //api/Provedores/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearProveedorDTO entidadDTO)
        {
            try
            {
                
                Proveedor entidad = mapper.Map<Proveedor>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Proveedores/1
        public async Task<ActionResult> Put(int id, [FromBody] Proveedor entidad)

        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos: el ID no coincide.");
            }
            var prov = await repositorio.SelectById(id);

            if (prov == null)
            {
                return NotFound("No existe el nombre del cliente.");
            }
            prov.Nombre = entidad.Nombre;
            prov.CUIT = entidad.CUIT;
            prov.Direccion = entidad.Direccion;
            prov.Estado = entidad.Estado;
            prov.FechaAlta = entidad.FechaAlta;
            prov.Activo = entidad.Activo;
            prov.Observacion = entidad.Observacion; ;

            try
            {
                await repositorio.Update(id, prov);
               
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//api/Proveedores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El proveedores {id} no existe.");
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
