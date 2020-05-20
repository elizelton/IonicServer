using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IonicServer.Entities
{
    public class Item : BaseEntity
    {
        [ForeignKey("Setor")]
        public int idSetor { get; set; }
       public Setor Setor { get; set; }
        public string Nome { get; set; }
       public bool Situacao { get; set; }

    }
}
