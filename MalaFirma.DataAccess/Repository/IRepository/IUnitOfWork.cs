using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IZamowienieRepository Zamowienie { get; }
        void Save();
    }
}
