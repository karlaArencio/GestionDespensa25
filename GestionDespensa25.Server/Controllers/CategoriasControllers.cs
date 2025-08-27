using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Controllers
{
    [ApiController]
    [Route("api/Categorias")]
    public class CategoriasControllers: ControllerBase
    {
        private readonly Context context;

        public CategoriasControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet] //api/Categorias
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await context.Categorias.ToListAsync();
        }

        [HttpGet("{id:int}")]//api/Categorias/existe/2
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            Categoria? categoria = await context.Categorias
                      .FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        [HttpGet("{nombre}")]//api/Categorias/
        public async Task<ActionResult<Categoria>> GetByNombre(string nombre)
        {
            Categoria? categoria = await context.Categorias
                      .FirstOrDefaultAsync(x => x.NombreCategoria == nombre);
            if (categoria == null)
            {
                return NotFound($"No se encontro la categoria con nombre:{nombre}");
            }
            return categoria;
        }

        [HttpGet("existe/{id:int}")] //api/Categorias/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Categorias.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearCategoriaDTO entidadDTO)
        {
            try
            {
                Categoria entidad = new Categoria();
                entidad.NombreCategoria = entidadDTO.NombreCategoria;

                context.Categorias.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Categorias/1
        public async Task<ActionResult> Put(int id, [FromBody] Categoria entidad)

        {
            if (id == entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var nom = await context.Categorias.
                      Where(e => e.Id == id)
                      .FirstOrDefaultAsync();

            if (nom == null)
            {
                return NotFound("No existe el nombre de la categoria.");
            }
            nom.NombreCategoria = entidad.NombreCategoria;
           

            try
            {
                context.Categorias.Update(nom);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]//api/Categorias/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Categorias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"la categorias {id} no existe.");
            }
            Categoria EntidadABorrar = new Categoria();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok($"La categoria {id} fue eliminada correctamente.");
        }


    }
}
