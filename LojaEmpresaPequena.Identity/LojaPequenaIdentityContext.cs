using LojaEmpresaPequena.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Identity
{
    public class LojaPequenaIdentityContext : IdentityDbContext<Usuario>
    {


        public LojaPequenaIdentityContext(DbContextOptions options): base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
