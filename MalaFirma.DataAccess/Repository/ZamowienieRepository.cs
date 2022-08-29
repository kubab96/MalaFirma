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

            if (_db.Zamowienia.FirstOrDefault() == null)
            {
                obj.Id = 1;
            }
            else
            {
                obj.Id = _db.Zamowienia.Max(x => x.Id + 1);

            }
            _db.Zamowienia.Add(obj);
        }
    }
}
