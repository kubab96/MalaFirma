﻿using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IZamowienieRepository : IRepository<Zamowienie>
    {
        void Update(Zamowienie obj);
        void AddId (Zamowienie obj);
        void Confirm (Zamowienie obj);
    }
}
