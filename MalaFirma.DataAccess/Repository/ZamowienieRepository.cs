using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class ZamowienieRepository : Repository<Zamowienie>, IZamowienieRepository
    {
        private ApplicationDbContext _db;

        public ZamowienieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Zamowienie obj)
        {
            _db.Zamowienia.Update(obj);
        }
        public void AddId(Zamowienie obj)
        {
            
            _db.Zamowienia.Add(obj);
        }
        public void Confirm(Zamowienie obj)
        {
            obj.Potwierdzenie = true;
            _db.Zamowienia.Add(obj);
        }
    }
}
