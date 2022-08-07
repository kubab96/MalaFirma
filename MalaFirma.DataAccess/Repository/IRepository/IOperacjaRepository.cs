using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IOperacjaRepository : IRepository<Operacja>
    {
        void Update(Operacja obj);
        void AddId(Operacja obj);
    }
}
