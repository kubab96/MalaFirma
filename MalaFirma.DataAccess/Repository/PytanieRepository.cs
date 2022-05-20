using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class PytanieRepository : Repository<Pytanie>, IPytanieRepository
    {
        private ApplicationDbContext _db;

        public PytanieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pytanie obj)
        {
            _db.Pytania.Update(obj);
        }
        public void AddId(Pytanie obj)
        {

            _db.Pytania.Add(obj);
        }
    }
}
