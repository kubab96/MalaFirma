using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface ISwiadectwoJakosciRepository : IRepository<SwiadectwoJakosci>
    {
        void Update(SwiadectwoJakosci obj);
        void AddId(SwiadectwoJakosci obj);
    }
}
