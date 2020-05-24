using LojaEmpresaPequena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaEmpresaPequena.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        public void  Save(Entity entidade);

        public void Delete(Guid id);

        public IQueryable<Entity> GetAll(int pageIndex = 0, int pageSize = 10);

        public Entity GetById(Guid id);

        public void Update(Entity entidade);
    }
}
