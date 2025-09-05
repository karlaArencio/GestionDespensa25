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
    [Route("api/Usuarios")]
    public class UsuariosControllers: ControllerBase
    {
        private readonly IUsuarioRepositorio repositorio;
        private readonly IMapper mapper;

        public UsuariosControllers(IUsuarioRepositorio repositorio,
                                   IMapper mapper)
        {
            
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet] //api/Usuarios
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]//api/Usuarios/existe/2
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            Usuario? nom = await repositorio.SelectById(id);
            if (nom == null)
            {
                return NotFound();
            }
            return nom;
        }

        [HttpGet("GetByNombre/{nombre}")]//api/Usuarios/por-nombre/Juan
        public async Task<ActionResult<Usuario>> GetByNombre(string nombre)
        {
            var usuario = await repositorio.SelectByNom(nombre);
            if (usuario == null)
            {
                return NotFound($"No se encontro el usuario con nombre: {nombre}");
            }
            return usuario;
        }

        [HttpGet("existe/{id:int}")] //api/Usuarios/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
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
                
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Usuarios/1
        public async Task<ActionResult> Put(int id, [FromBody] Usuario entidad)

        {
            if (id != entidad.Id)
            {
                return BadRequest("El id del usuario no coinciden con el id de la entidad ");
            }
            var usuario = await repositorio.SelectById(id);

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
                await repositorio.Update(id, usuario);
                
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
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El usuario {id} no existe.");
            }
            if(await repositorio.Delete(id))
            {
                return Ok($"El usuario {id} fue eliminado correctamente.");
            }
            else
            {
                return BadRequest("No se pudo eliminar el usuario.");
            }
        }
    }
}

