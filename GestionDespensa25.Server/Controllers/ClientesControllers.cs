using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace GestionDespensa25.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesControllers : ControllerBase
    {
        private readonly Context context;
        public ClientesControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet] //api/Clientes
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpGet("{id:int}")]//api/Clientes/existe/2
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            Cliente? nom = await context.Clientes
                      .FirstOrDefaultAsync(x => x.Id == id);
            if (nom ==null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("{ape}")]//api/Clientes/Apellido
        public async Task<ActionResult<Cliente>> GetByApe(string ape)
        {
            Cliente? nom = await context.Clientes
                      .FirstOrDefaultAsync(x => x.Apellido == ape);
            if (nom == null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("existe/{id:int}")] //api/Clientes/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente entidad)
        {
            try
            {
                context.Clientes.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Clientes/1
        public async Task<ActionResult> Put(int id, [FromBody] Cliente entidad)

        {
            if (id==entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var nom = await context.Clientes.
                      Where(e=> e.Id==id)
                      .FirstOrDefaultAsync();

            if(nom == null)
            {
                return NotFound("No existe el nombre del cliente.");
            }
            nom.Nombre = entidad.Nombre;
            nom.Apellido = entidad.Apellido;
            nom.DNI = entidad.DNI;
            nom.Telefono = entidad.Telefono;
            nom.Direccion = entidad.Direccion;
            nom.Activo = entidad.Activo;
            
            try
            {
                context.Clientes.Update(nom);
                await context.SaveChangesAsync();
                return  Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//api/Clientes/2
        public async Task<ActionResult>Delete(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El clientes {id} no existe.");
            }
            Cliente EntidadABorrar = new Cliente();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok($"El cliente {id} fue eliminado correctamente.");
        }
    }
            
}
