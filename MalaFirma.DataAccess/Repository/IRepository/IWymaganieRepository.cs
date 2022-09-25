using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IWymaganieRepository : IRepository<Wymaganie>
    {
        void Update(Wymaganie obj);
        void AddId(Wymaganie obj, int id);
    }
}
