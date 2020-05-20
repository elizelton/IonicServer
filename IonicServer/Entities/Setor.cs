using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IonicServer.Entities
{
    public class Setor : BaseEntity
    {
       public string Nome { get; set; }
       public bool Situacao { get; set; }

    }
}
