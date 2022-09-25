using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface INarzedzieRepository : IRepository<Narzedzie>
    {
        void Update(Narzedzie obj);
        void AddId(Narzedzie obj);
    }
}
