using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IDostawcaRepository : IRepository<Dostawca>
    {
        void Update(Dostawca obj);
        void AddId(Dostawca obj);
    }
}
