using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
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
            Wymaganie = new WymaganieRepository(_db);
            Pytanie = new PytanieRepository(_db);
            Odpowiedz = new OdpowiedzRepository(_db);
            Narzedzie = new NarzedzieRepository(_db);
            TypNarzedzia = new TypNarzedziaRepository(_db);
            Dostawca = new DostawcaRepository(_db);
            Przeglad = new PrzegladRepository(_db);
            Klient = new KlientRepository(_db);
            KartaProjektu = new KartaProjektuRepository(_db);
            PrzewodnikPracy = new PrzewodnikPracyRepository(_db);
            Operacja = new OperacjaRepository(_db);
            SwiadectwoJakosci = new SwiadectwoJakosciRepository(_db);
            ObslugaMetrologiczna = new ObslugaMetrologicznaRepository(_db);
            Audyt = new AudytRepository(_db);
            Szkolenie = new SzkolenieRepository(_db);
            Przywieszka = new PrzywieszkaRepository(_db);
            ZadowolenieKlienta = new ZadowolenieKlientaRepository(_db);
        }
        public IZamowienieRepository Zamowienie { get; private set; }
        public IWymaganieRepository Wymaganie { get; private set; }
        public IPytanieRepository Pytanie { get; private set; }
        public IOdpowiedzRepository Odpowiedz { get; private set; }
        public INarzedzieRepository Narzedzie { get; private set; }
        public ITypNarzedziaRepository TypNarzedzia { get; private set; }
        public IDostawcaRepository Dostawca { get; private set; }
        public IPrzegladRepository Przeglad { get; private set; }
        public IKlientRepository Klient { get; private set; }
        public IKartaProjektuRepository KartaProjektu { get; private set; }
        public IPrzewodnikPracyRepository PrzewodnikPracy { get; private set; }
        public IOperacjaRepository Operacja { get; private set; }
        public ISwiadectwoJakosciRepository SwiadectwoJakosci { get; private set; }
        public IObslugaMetrologicznaRepository ObslugaMetrologiczna { get; private set; }
        public IAudytRepository Audyt { get; private set; }
        public ISzkolenieRepository Szkolenie { get; private set; }
        public IPrzywieszkaRepository Przywieszka { get; private set; }
        public IZadowolenieKlientaRepository ZadowolenieKlienta { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
