using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaEmpresaPequena.Context.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {

        private readonly DbSet<Entity>  _dbSet;
        private readonly LojaEmpresaPequenaIdentity _context;


        public BaseRepository(LojaEmpresaPequenaIdentity context)
        {
            _dbSet = context.Set<Entity>();
        }

        public void Delete(Guid id)
        {
            var entityFromDb = _dbSet.Find(id);
            _context.SaveChanges();
        }

        public IQueryable<Entity> GetAll(int pageIndex = 0, int pageSize = 10)
        {
            var listFromDb = _dbSet.Skip(pageIndex).Take(pageSize);
            return listFromDb;
        }

        public Entity GetById(Guid id)
        {
            var entityFromDb = _dbSet.Find(id);
            return entityFromDb;
        }

        public void Save(Entity entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Update(Entity entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }
    }
}
