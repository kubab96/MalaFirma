using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class AudytRepository : Repository<Audyt>, IAudytRepository
    {
        private ApplicationDbContext _db;

        public AudytRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Audyt obj)
        {
            _db.Audyty.Update(obj);
        }
        public void AddId(Audyt obj)
        {
            _db.Audyty.Add(obj);
        }
    }
}
