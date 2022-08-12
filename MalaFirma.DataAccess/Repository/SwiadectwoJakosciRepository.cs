using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class SwiadectwoJakosciRepository : Repository<SwiadectwoJakosci>, ISwiadectwoJakosciRepository
    {
        private ApplicationDbContext _db;

        public SwiadectwoJakosciRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SwiadectwoJakosci obj)
        {
            _db.SwiadectwoJakosci.Update(obj);
        }
        public void AddId(SwiadectwoJakosci obj)
        {

            _db.SwiadectwoJakosci.Add(obj);
        }
    }
}
