using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public Usuario(global::System.Int32 id, global::System.String nome, global::System.String cpf, global::System.String email, global::System.String role)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Role = role;
        }

        public Usuario()
        {
        }
    }
}
