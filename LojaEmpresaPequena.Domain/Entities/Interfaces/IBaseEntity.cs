using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities.Interfaces
{
    public interface IBaseEntity<E>
    {
        public void UpdateInstance(E e);
    }
}
