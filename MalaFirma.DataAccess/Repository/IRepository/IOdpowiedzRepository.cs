using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IOdpowiedzRepository : IRepository<Odpowiedz>
    {
        void Update(Odpowiedz obj, int idPytania, int idZamowienia);
        void AddId(Odpowiedz obj, int idPytania, int idZamowienia);
    }
}
