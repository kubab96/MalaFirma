using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class KartaProjektuRepository : Repository<KartaProjektu>, IKartaProjektuRepository
    {
        private ApplicationDbContext _db;

        public KartaProjektuRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(KartaProjektu obj)
        {
            _db.KartaProjektu.Update(obj);
        }
        public void AddId(KartaProjektu obj)
        {

            _db.KartaProjektu.Add(obj);
        }
    }
}
