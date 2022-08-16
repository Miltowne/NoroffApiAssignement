﻿using Appenix_B_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.ALT_Repositories
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        public List<Employee> GetPartTimeEmployee();
    }
}
