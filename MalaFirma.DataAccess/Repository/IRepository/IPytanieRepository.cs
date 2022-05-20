using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IPytanieRepository : IRepository<Pytanie>
    {
        void Update(Pytanie obj);
        void AddId(Pytanie obj);
    }
}
