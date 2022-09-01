using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface ISzkolenieRepository : IRepository<Szkolenie>
    {
        void Update(Szkolenie obj);
        void AddId(Szkolenie obj);
    }
}
