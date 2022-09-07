﻿using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IRysunekPrzewodnikaRepository : IRepository<RysunekPrzewodnika>
    {
        void Update(RysunekPrzewodnika obj);
        void AddId(RysunekPrzewodnika obj);
    }
}