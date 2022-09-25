using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IZadowolenieKlientaRepository : IRepository<ZadowolenieKlienta>
    {
        void Update(ZadowolenieKlienta obj);
        void AddId(ZadowolenieKlienta obj);
    }
}
