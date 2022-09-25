using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{

    public interface IObslugaMetrologicznaRepository : IRepository<ObslugaMetrologiczna>
    {
        void Update(ObslugaMetrologiczna obj);
        void AddId(ObslugaMetrologiczna obj);
    }
}
