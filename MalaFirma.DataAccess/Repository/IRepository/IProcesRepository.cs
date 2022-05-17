using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IProcesRepository : IRepository<Proces>
    {
        void Update(Proces obj);
        void AddId(Proces obj, int id);
    }
}
