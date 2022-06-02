using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class PrzegladRepository : Repository<Przeglad>, IPrzegladRepository
    {
        private ApplicationDbContext _db;

        public PrzegladRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Przeglad obj, int idZamowienia)
        {
            obj.zamowienieId = idZamowienia;
            _db.Przeglady.Update(obj);
        }
        public void AddId(Przeglad obj, int idZamowienia)
        {
            obj.zamowienieId = idZamowienia;
            _db.Przeglady.Add(obj);
        }
    }
}
