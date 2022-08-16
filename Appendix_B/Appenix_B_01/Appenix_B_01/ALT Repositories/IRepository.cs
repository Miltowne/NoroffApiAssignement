﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.ALT_Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Edit(T entity);
        bool Delete(T entity);
    }
}