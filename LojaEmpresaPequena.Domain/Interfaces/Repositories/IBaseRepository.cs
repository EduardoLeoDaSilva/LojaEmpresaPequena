using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<Entity> where Entity : class // BaseEntity<Entity>
    {
        public Task Save(Entity entidade);

        public Task Delete(Guid id);

        public IQueryable<Entity> GetAll();

        public Task<Entity> GetById(Guid id);

        public Task Update(Entity entidade);
    }
}
