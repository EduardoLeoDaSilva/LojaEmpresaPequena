using LojaEmpresaPequena.Domain.Entities.Interfaces;
using LojaEmpresaPequena.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class BaseEntity<E>: IBaseEntity<E>
    {
        public Guid Id { get; set; }

        public virtual void UpdateInstance(E e)
        {
            throw new NotImplementedException(ProgramMessages.MetodoNImplementado);
        }
    }
}
