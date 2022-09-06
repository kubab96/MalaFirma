using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IZadowolenieKlientaRepository : IRepository<ZadowolenieKlienta>
    {
        void Update(ZadowolenieKlienta obj);
        void AddId(ZadowolenieKlienta obj);
    }
}
