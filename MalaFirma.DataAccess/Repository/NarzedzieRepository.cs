using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class NarzedzieRepository : Repository<Narzedzie>, INarzedzieRepository
    {
        private ApplicationDbContext _db;

        public NarzedzieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Narzedzie obj)
        {
            var objFromDb = _db.Narzedzia.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Nazwa = obj.Nazwa;
                objFromDb.NumerFabryczny = obj.NumerFabryczny;
                objFromDb.ObslugaMetrologiczna = obj.ObslugaMetrologiczna;
                objFromDb.Status = obj.Status;
                objFromDb.NumerFabryczny = obj.NumerFabryczny;
                objFromDb.TypNarzedziaId = obj.TypNarzedziaId;
            }
        }
        public void AddId(Narzedzie obj)
        {

            _db.Narzedzia.Add(obj);
        }
    }
}
