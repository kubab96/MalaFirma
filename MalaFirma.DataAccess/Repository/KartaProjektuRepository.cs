using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
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
            if (_db.KartaProjektu.FirstOrDefault() == null)
            {
                obj.Id = 1;
            }
            else
            {
                obj.Id = _db.KartaProjektu.Max(x => x.Id + 1);

            }
            _db.KartaProjektu.Add(obj);
        }
    }
}
