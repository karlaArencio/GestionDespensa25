using AutoMapper;
using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class UsuariosControllers: ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public UsuariosControllers(Context context,
                                   IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet] //api/Usuarios
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        [HttpGet("{id:int}")]//api/Usuarios/existe/2
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? nom = await context.Usuarios
                      .FirstOrDefaultAsync(x => x.Id == id);
            if (nom == null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("{nombre}")]//api/Usuarios/
        public async Task<ActionResult<Usuario>> GetByApe(string nombre)
        {
            var usuario = await context.Usuarios
                      .FirstOrDefaultAsync(x => x.NombreUsuario == nombre);
            if (usuario == null)
            {
                return NotFound($"No se encontro el usuario con nombre: {nombre}");
            }
            return usuario;
        }

        [HttpGet("existe/{id:int}")] //api/Usuarios/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                //Usuario entidad = new Usuario();
                //entidad.NombreUsuario = entidadDTO.NombreUsuario;
                //entidad.Clave = entidadDTO.Clave;
                //entidad.Rol=entidadDTO.Rol;
                Usuario entidad = mapper.Map<Usuario>(entidadDTO);
                context.Usuarios.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Usuarios/1
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)

        {
            if (id != entidad.Id)
            {
                return BadRequest("El id del usuario no coinciden con el id de la entidad ");
            }
            var usuario = await context.Usuarios.
                      Where(e => e.Id == id)
                      .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound("No existe el nombre del usuario.");
            }
            //actualizar campos
            usuario.NombreUsuario = entidad.NombreUsuario;
            usuario.Clave = entidad.Clave;
            

            try
            {
                // Opción 1: explícita
                // Opción 2: implícita, EF detecta cambios
                // await context.SaveChangesAsync();
                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync(); 
                return Ok("Usuario actualizado correctamente.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//api/Usuarios/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El usuario {id} no existe.");
            }
            Usuario EntidadABorrar = new Usuario();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok($"El usuario {id} fue eliminado correctamente.");
        }
    }
}

