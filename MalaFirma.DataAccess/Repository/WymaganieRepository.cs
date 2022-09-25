using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
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
        public void AddId(Wymaganie obj, int id)
        {
            if (_db.Wymagania.FirstOrDefault() == null)
            {
                obj.Id = 1;
            }
            else
            {
                obj.Id = _db.Wymagania.Max(x => x.Id + 1);

            }
            obj.ZamowienieId = id;
            _db.Wymagania.Add(obj);
        }
    }
}
