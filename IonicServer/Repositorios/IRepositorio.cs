﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skoll.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        bool Existe(int id);
        int Contar();
    }
}
