using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
{
    public class RysunekPrzewodnikaRepository : Repository<RysunekPrzewodnika>, IRysunekPrzewodnikaRepository
    {
        private ApplicationDbContext _db;

        public RysunekPrzewodnikaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(RysunekPrzewodnika obj)
        {
            _db.RysunekPrzewodnikow.Update(obj);
        }
        public void AddId(RysunekPrzewodnika obj)
        {
            _db.RysunekPrzewodnikow.Add(obj);
        }
    }
}
