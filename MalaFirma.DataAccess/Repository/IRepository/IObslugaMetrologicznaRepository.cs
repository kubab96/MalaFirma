using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{

    public interface IObslugaMetrologicznaRepository : IRepository<ObslugaMetrologiczna>
    {
        void Update(ObslugaMetrologiczna obj);
        void AddId(ObslugaMetrologiczna obj);
    }
}
