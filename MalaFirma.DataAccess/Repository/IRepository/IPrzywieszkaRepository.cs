using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IPrzywieszkaRepository : IRepository<Przywieszka>
    {
        void Update(Przywieszka obj);
        void AddId(Przywieszka obj);
    }
}
