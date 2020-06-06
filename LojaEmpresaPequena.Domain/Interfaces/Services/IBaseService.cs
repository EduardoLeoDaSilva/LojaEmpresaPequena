using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IBaseService<Entity> where Entity : BaseEntity<Entity>
    {

        public  Task Save(Entity entity);
        public Task Delete(Guid id);
        public Task Update(Entity entity);
        public IQueryable<Entity> GetAll();
        public Task<Entity> GetById(Guid id);

    }
}
