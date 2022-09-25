using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IAudytRepository : IRepository<Audyt>
    {
        void Update(Audyt obj);
        void AddId(Audyt obj);
    }
}
