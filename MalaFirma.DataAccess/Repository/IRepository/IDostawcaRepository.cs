using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IDostawcaRepository : IRepository<Dostawca>
    {
        void Update(Dostawca obj);
        void AddId(Dostawca obj);
    }
}
