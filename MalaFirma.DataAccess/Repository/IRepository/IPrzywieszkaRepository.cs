using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IPrzywieszkaRepository : IRepository<Przywieszka>
    {
        void Update(Przywieszka obj);
        void AddId(Przywieszka obj);
    }
}
