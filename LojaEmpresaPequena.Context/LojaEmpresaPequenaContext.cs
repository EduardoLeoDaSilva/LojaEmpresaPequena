using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Context
{
    public class LojaEmpresaPequenaContext : DbContext
    {

        public LojaEmpresaPequenaContext(DbContextOptions options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
