using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class OdpowiedzRepository : Repository<Odpowiedz>, IOdpowiedzRepository
    {
        private ApplicationDbContext _db;

        public OdpowiedzRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Odpowiedz obj, int idPytania, int idZamowienia)
        {
            obj.PytanieId = idPytania;
            obj.ZamowienieId = idZamowienia;
            if (obj.Wartosc == false)
            {
                obj.Status = "Nie";
            }
            else
            {
                obj.Status = "Tak";
            }
            _db.Odpowiedzi.Update(obj);
        }
        public void AddId(Odpowiedz obj, int idPytania, int idZamowienia)
        {
            obj.PytanieId = idPytania;
            obj.ZamowienieId = idZamowienia;
            if (obj.Wartosc == false)
            {
                obj.Status = "Nie";
            }
            else
            {
                obj.Status = "Tak";
            }
            _db.Odpowiedzi.Add(obj);
        }
    }
}
