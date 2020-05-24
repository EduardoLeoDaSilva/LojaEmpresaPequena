using LojaEmpresaPequena.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LojaEmpresaPequena.Context
{

        public class LojaEmpresaPequenaIdentity : IdentityDbContext<Usuario>
        {


            public LojaEmpresaPequenaIdentity(DbContextOptions options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                base.OnModelCreating(builder);
            }

        }
    
}
