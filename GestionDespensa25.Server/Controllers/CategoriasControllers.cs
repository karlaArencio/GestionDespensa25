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
    [Route("api/Categorias")]
    public class CategoriasControllers: ControllerBase
    {
        private readonly ICategoriaRepositorio repositorio;
        private readonly IMapper mapper;

        public CategoriasControllers(ICategoriaRepositorio repositorio,
                                     IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet] //api/Categorias
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]//api/Categorias/2
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            Categoria? dim = await repositorio.SelectById(id);
            if (dim == null)
            {
                return NotFound();
            }
            return dim;
        }

       [HttpGet("GetByNom/{nombre}")]//api/Categorias/GetByNom/Bebidas
        public async Task<ActionResult<Categoria>> GetByNom(string nombre)
        {

            var dim = await repositorio.SelectByNom(nombre);

           if (dim == null)
           {
                return NotFound($"No se encontro la categoria con nombre:{nombre}");
            }
            return Ok(dim);
            //Categoria?  dim =await repositorio.SelectByNom(nombre);
            //if (dim ==null)
            //{
            // return NotFound();
            //}
            //return dim;
        }

        [HttpGet("existe/{id:int}")] //api/Categorias/existe/1
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Categoria entidad)
        {
            try
            {        
                //Categoria entidad = mapper.Map<Categoria>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message); //BadRequest:codigo de estado http 404
            }
        }

        [HttpPut("{id:int}")]//api/Categorias/1
        public async Task<ActionResult<bool>> Put(int id, [FromBody] Categoria entidad)
         
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
                    return BadRequest("No existe la categoria.");
                }
                return nom;
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]//api/Categorias/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            { return BadRequest("La categoria no se puede borrar "); }
                return Ok();
        
            //var existe = await repositorio.Existe(id);
            //if (!existe)
            //{
            //    return NotFound($"la categorias {id} no existe.");
            //}
            //if (await repositorio.Delete(id))
            //{
            //    return Ok();
            //}
            //else 
            //{
            //    return BadRequest();
            //}
               
        }

    }
}
