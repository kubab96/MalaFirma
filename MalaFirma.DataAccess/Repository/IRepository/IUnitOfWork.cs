using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IZamowienieRepository Zamowienie { get; }
        IWymaganieRepository Wymaganie { get; }
        IPytanieRepository Pytanie { get; }
        IOdpowiedzRepository Odpowiedz { get; }
        INarzedzieRepository Narzedzie { get; }
        ITypNarzedziaRepository TypNarzedzia { get; }
        IDostawcaRepository Dostawca { get; }
        IPrzegladRepository Przeglad { get; }
        IKlientRepository Klient { get; }   
        IKartaProjektuRepository KartaProjektu { get; }
        IPrzewodnikPracyRepository PrzewodnikPracy { get; }
        IOperacjaRepository Operacja { get; }
        IObslugaMetrologicznaRepository ObslugaMetrologiczna { get; }
        ISwiadectwoJakosciRepository SwiadectwoJakosci { get; }
        IAudytRepository Audyt { get; }
        ISzkolenieRepository Szkolenie { get; }
        IPrzywieszkaRepository Przywieszka { get; }
        IZadowolenieKlientaRepository ZadowolenieKlienta { get;  }
        IRysunekPrzewodnikaRepository RysunekPrzewodnika { get; }

        void Save();
    }
}
