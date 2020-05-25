using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services
{
    public interface IBaseService<Entity> where Entity : BaseEntity
    {

        public void Save(Entity entity);
        public void Delete(Guid id);
        public void Update(Entity entity);
        public IQueryable<Entity> GetAll();
        public Task<Entity> GetById(Guid id);

    }
}
