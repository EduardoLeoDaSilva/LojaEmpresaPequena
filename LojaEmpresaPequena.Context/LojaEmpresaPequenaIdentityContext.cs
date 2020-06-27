using LojaEmpresaPequena.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LojaEmpresaPequena.Context
{

    public class LojaEmpresaPequenaIdentityContext : IdentityDbContext<Usuario>
    {


        public LojaEmpresaPequenaIdentityContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
            //this.Roles.Add(new IdentityRole("Admin"));
            //this.Roles.Add(new IdentityRole("Cliente"));
            //this.SaveChanges();
        }


    }

}
