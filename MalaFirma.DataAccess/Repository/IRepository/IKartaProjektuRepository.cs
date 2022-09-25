using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IKartaProjektuRepository : IRepository<KartaProjektu>
    {
        void Update(KartaProjektu obj);
        void AddId(KartaProjektu obj);
    }
}
