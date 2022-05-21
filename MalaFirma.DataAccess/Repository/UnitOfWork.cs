using MalaFirma.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Zamowienie = new ZamowienieRepository(_db);
            Proces = new ProcesRepository(_db);
            Pytanie = new PytanieRepository(_db);
            Odpowiedz = new OdpowiedzRepository(_db);
        }
        public IZamowienieRepository Zamowienie { get; private set; }
        public IProcesRepository Proces { get; private set; }
        public IPytanieRepository Pytanie { get; private set; }
        public IOdpowiedzRepository Odpowiedz { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
