using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
{
    public class KlientRepository : Repository<Klient>, IKlientRepository
    {
        private ApplicationDbContext _db;

        public KlientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Klient obj)
        {
            var objFromDb = _db.Klient.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.NazwaKlienta = obj.NazwaKlienta;
                objFromDb.Kraj = obj.Kraj;
                objFromDb.Miasto = obj.Miasto;
                objFromDb.UlicaNumer = obj.UlicaNumer;
                objFromDb.KodPocztowy = obj.KodPocztowy;
            }
        }
        public void AddId(Klient obj)
        {

            _db.Klient.Add(obj);
        }
    }
}
