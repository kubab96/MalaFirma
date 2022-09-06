using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class ZadowolenieKlientaRepository : Repository<ZadowolenieKlienta>, IZadowolenieKlientaRepository
    {
        private ApplicationDbContext _db;

        public ZadowolenieKlientaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ZadowolenieKlienta obj)
        {
            _db.ZadowolenieKlientow.Update(obj);
        }
        public void AddId(ZadowolenieKlienta obj)
        {
            _db.ZadowolenieKlientow.Add(obj);
        }
    }
}
