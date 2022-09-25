using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IKlientRepository : IRepository<Klient>
    {
        void Update(Klient obj);
        void AddId(Klient obj);
    }
}
