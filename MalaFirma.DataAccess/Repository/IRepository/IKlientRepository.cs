using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IKlientRepository : IRepository<Klient>
    {
        void Update(Klient obj);
        void AddId(Klient obj);
    }
}
