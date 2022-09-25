using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;

namespace SimpleQMS.DataAccess.Repository
{
    public class PrzewodnikPracyRepository : Repository<PrzewodnikPracy>, IPrzewodnikPracyRepository
    {
        private ApplicationDbContext _db;

        public PrzewodnikPracyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }   

        public void Update(PrzewodnikPracy obj)
        {
            _db.PrzewodnikPracy.Update(obj);
        }
        public void AddId(PrzewodnikPracy obj)
        {

            _db.PrzewodnikPracy.Add(obj);
        }
    }
}
