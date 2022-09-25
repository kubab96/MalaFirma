using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleQMS.Models;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IPrzewodnikPracyRepository : IRepository<PrzewodnikPracy>
    {
        void Update(PrzewodnikPracy obj);
        void AddId(PrzewodnikPracy obj);
    }
}
