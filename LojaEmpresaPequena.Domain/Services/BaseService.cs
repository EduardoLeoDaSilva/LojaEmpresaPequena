using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Interfaces.Repositories;
using LojaEmpresaPequena.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services
{
    public class BaseService<Entity> : IBaseService<Entity> where Entity : BaseEntity<Entity>
    {
        private readonly IBaseRepository<Entity> _repository;
        public BaseService(IBaseRepository<Entity> repository)
        {
            _repository = repository;
        }

        public async virtual Task Save(Entity entity)
        {
            await _repository.Save(entity);
        }

        public async virtual Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async virtual Task Update(Entity entity)
        {
            await _repository.Update(entity);
        }

        public virtual IQueryable<Entity> GetAll() 
        {
            return _repository.GetAll();
        }

        public async virtual Task<Entity> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

    }
}
