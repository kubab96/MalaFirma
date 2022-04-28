using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class WymaganieRepository : Repository<Wymaganie>, IWymaganieRepository
    {
        private ApplicationDbContext _db;

        public WymaganieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Wymaganie obj)
        {
            _db.Wymagania.Update(obj);
        }
    }
}
