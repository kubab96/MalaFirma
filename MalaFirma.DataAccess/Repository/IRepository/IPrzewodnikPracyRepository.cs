using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaFirma.Models;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IPrzewodnikPracyRepository : IRepository<PrzewodnikPracy>
    {
        void Update(PrzewodnikPracy obj);
        void AddId(PrzewodnikPracy obj);
    }
}
