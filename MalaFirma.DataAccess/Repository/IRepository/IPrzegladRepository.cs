using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IPrzegladRepository : IRepository<Przeglad>
    {
        void Update(Przeglad obj);
        void AddId(Przeglad obj, int idZamowienia);
    }
}
