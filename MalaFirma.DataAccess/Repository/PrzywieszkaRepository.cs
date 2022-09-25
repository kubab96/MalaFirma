using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
{
    public class PrzywieszkaRepository : Repository<Przywieszka>, IPrzywieszkaRepository
    {
        private ApplicationDbContext _db;

        public PrzywieszkaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Przywieszka obj)
        {
            _db.Przywieszki.Update(obj);
        }
        public void AddId(Przywieszka obj)
        {
            _db.Przywieszki.Add(obj);
        }
    }
}
