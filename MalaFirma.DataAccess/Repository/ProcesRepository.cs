using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class ProcesRepository : Repository<Proces>, IProcesRepository
    {
        private ApplicationDbContext _db;

        public ProcesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Proces obj)
        {
            _db.Procesy.Update(obj);
        }
        public void AddId(Proces obj, int id)
        {
            if (_db.Procesy.FirstOrDefault() == null)
            {
                obj.Id = 1;
            }
            else
            {
                obj.Id = _db.Procesy.Max(x => x.Id + 1);

            }
            obj.ZamowienieId = id;
            _db.Procesy.Add(obj);
        }
    }
}
