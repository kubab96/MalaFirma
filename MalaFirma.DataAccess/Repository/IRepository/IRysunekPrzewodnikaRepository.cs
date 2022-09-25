﻿using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IRysunekPrzewodnikaRepository : IRepository<RysunekPrzewodnika>
    {
        void Update(RysunekPrzewodnika obj);
        void AddId(RysunekPrzewodnika obj);
    }
}
