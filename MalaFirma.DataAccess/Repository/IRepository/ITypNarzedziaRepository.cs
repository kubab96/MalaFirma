using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleQMS.Models;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface ITypNarzedziaRepository : IRepository<TypNarzedzia>
    {
        void Update(TypNarzedzia obj);
        void AddId(TypNarzedzia obj);
    }
}
