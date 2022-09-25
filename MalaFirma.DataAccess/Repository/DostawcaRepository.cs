using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
{
    public class DostawcaRepository : Repository<Dostawca>, IDostawcaRepository
    {
        private ApplicationDbContext _db;

        public DostawcaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Dostawca obj)
        {
            var objFromDb = _db.Dostawcy.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.NazwaDostawcy = obj.NazwaDostawcy;
                objFromDb.AdresDostwacy = obj.AdresDostwacy;
                objFromDb.ZakresDzialalnosci = obj.ZakresDzialalnosci;
                objFromDb.DataZatwierdzenia = obj.DataZatwierdzenia;
                objFromDb.DataWygasniecia = obj.DataWygasniecia;
                objFromDb.Uwagi = obj.Uwagi;
            }
        }
        public void AddId(Dostawca obj)
        {
            _db.Dostawcy.Add(obj);
        }
    }
}
