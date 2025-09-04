using AutoMapper;
using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Server.Repositorio;
using GestionDespensa25.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace GestionDespensa25.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesControllers : ControllerBase
    {
        private readonly IClienteRepositorio repositorio;
        private readonly IMapper mapper;

        public ClientesControllers(IClienteRepositorio repositorio)
        {
            
            this.repositorio = repositorio;
        }

        [HttpGet] //api/Clientes
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]//api/Clientes/existe/2
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            Cliente? nom = await repositorio.SelectById(id);
            if (nom ==null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("{ape}")]//api/Clientes/Apellido
        public async Task<ActionResult<Cliente>> GetByApe(string ape)
        {
            Cliente? nom = await repositorio.SelectByApe(ape);
            if (nom == null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("existe/{id:int}")] //api/Clientes/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente entidad)
        {
            try
            {
                //Cliente entidad = new Cliente();
                //entidad.Nombre = entidadDTO.Nombre;
                //entidad.Apellido = entidadDTO.Apellido;
                //entidad.DNI = entidadDTO.DNI;
                //entidad.Telefono = entidadDTO.Telefono;
                //entidad.Direccion = entidadDTO.Direccion;
                //entidad.Estado = entidadDTO.Estado;

                //Cliente entidad = mapper.Map<Cliente>(entidadDTO);
               
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Clientes/1
        public async Task<ActionResult> Put(int id, [FromBody] Cliente entidad)

        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var nom = await repositorio.Update(id, entidad);

                if (!nom)
                {
                    return NotFound("No sepudo actualizar el cliente.");
                }
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//api/Clientes/2
        public async Task<ActionResult>Delete(int id)
        {
            var resp= await repositorio.Delete(id);
            if (!resp)
            { return BadRequest("El cliente no se pudo borrar"); }
            return Ok($"El cliente {id} fue eliminado correctamente.");
        }
    }
            
}
