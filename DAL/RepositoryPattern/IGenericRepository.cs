﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
