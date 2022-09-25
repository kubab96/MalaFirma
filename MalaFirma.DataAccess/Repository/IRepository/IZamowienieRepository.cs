using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IZamowienieRepository : IRepository<Zamowienie>
    {
        void Update(Zamowienie obj);
        void AddId (Zamowienie obj);
    }
}
