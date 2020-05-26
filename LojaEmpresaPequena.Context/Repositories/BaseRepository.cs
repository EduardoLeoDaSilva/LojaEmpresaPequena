using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity<Entity>
    {

        protected readonly DbSet<Entity>  _dbSet;
        protected readonly LojaEmpresaPequenaIdentity _context;


        public BaseRepository(LojaEmpresaPequenaIdentity context)
        {
            _context = context;
            _dbSet = context.Set<Entity>();
        }

        public async virtual void Delete(Guid id)
        {
            var entityFromDb = await _dbSet.FindAsync(id);
            _context.SaveChanges();
        }

        public virtual IQueryable<Entity> GetAll()
        {
            var listFromDb = _dbSet;
            return listFromDb;
        }

        public async virtual Task<Entity> GetById(Guid id)
        {
            var entityFromDb = await _dbSet.FindAsync(id);
            return entityFromDb;
        }

        public async virtual void Save(Entity entidade)
        {
            _dbSet.Add(entidade);
           await _context.SaveChangesAsync();
        }

        public async virtual void Update(Entity entidade)
        {
            _dbSet.Update(entidade);
           await _context.SaveChangesAsync();
        }
    }
}
