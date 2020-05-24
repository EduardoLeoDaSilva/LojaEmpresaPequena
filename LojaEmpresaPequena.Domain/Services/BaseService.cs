using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaEmpresaPequena.Domain.Services
{
    public class BaseService<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        IBaseRepository<Entity> _repository;
        public BaseService(IBaseRepository<Entity> repository)
        {
            _repository = repository;
        }

        public virtual void Save(Entity entity)
        {
            _repository.Save(entity);
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public virtual void Update(Entity entity)
        {
            _repository.Save(entity);
        }

        public virtual IQueryable<Entity> GetAll(int pageIndex = 0, int pageSize = 10) 
        {
            return _repository.GetAll(pageIndex, pageSize);
        }

        public virtual Entity GetById(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
