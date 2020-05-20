using Core.Entities;
using IonicServer.Entities;
using Skoll.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skoll.Data
{
    public interface IUnitOfWork
    {
        IRepositorio<Usuario> UsuarioRepositorio { get; }
        IRepositorio<Setor> SetorRepositorio { get; }
        IRepositorio<Item> ItemRepositorio { get; }

        void Commit();
        void RollBack();
    }
}
