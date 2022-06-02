using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IPrzegladRepository : IRepository<Przeglad>
    {
        void Update(Przeglad obj, int idZamowienia);
        void AddId(Przeglad obj, int idZamowienia);
    }
}
