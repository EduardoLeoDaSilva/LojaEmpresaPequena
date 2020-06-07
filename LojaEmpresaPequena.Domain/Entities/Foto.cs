using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Foto :BaseEntity<Foto>
    {
        [JsonIgnore]
        public Produto  Produto { get; set; }
        public string Url { get; set; }
    }
}
