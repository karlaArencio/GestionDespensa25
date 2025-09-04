using AutoMapper;
using GestionDespensa25.BD.Data;
using GestionDespensa25.BD.Data.Entity;
using GestionDespensa25.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDespensa25.Server.Repositorio
{
    public class Repositorio<E> : IRepositorio<E>
                 where E : class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                         .AnyAsync(x => x.Id == id);
            return existe;
        }
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? nom = await context.Set<E>()
                      .AsNoTracking()
                      .FirstOrDefaultAsync(x => x.Id == id);

            return nom;
        }
       

        public async Task<int> Insert(E entidad)
        {
            try
            {

                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> Update(int id, E entidad)

        {
            if (id != entidad.Id)
            {
                return false;
            }
            var nom = await SelectById(id);
            

            if (nom == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var nom = await SelectById(id);
            if (nom==null)
            {
                return false;
            }

            context.Set<E>().Remove(nom);
            await context.SaveChangesAsync();
            return true;
        }

        //public async Task<E?> SelectByNombre(string nombre)
        //{
        //    return await context.Set<E>()
        //                   .AsNoTracking()
        //        .FirstOrDefaultAsync(x=> x.Nombre== nombre);
        //}
    }
}
