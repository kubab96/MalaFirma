using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface ISwiadectwoJakosciRepository : IRepository<SwiadectwoJakosci>
    {
        void Update(SwiadectwoJakosci obj);
        void AddId(SwiadectwoJakosci obj);
    }
}
