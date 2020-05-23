using System;
using System.Collections.Generic;
using System.Text;

namespace TEste
{
    public class Contexto : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }



        public LojaPequenaContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
