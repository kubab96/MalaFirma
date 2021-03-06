using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IZamowienieRepository Zamowienie { get; }
        IProcesRepository Proces { get; }
        IPytanieRepository Pytanie { get; }
        IOdpowiedzRepository Odpowiedz { get; }
        INarzedzieRepository Narzedzie { get; }
        ITypNarzedziaRepository TypNarzedzia { get; }
        IDostawcaRepository Dostawca { get; }
        IPrzegladRepository Przeglad { get; }
        IKlientRepository Klient { get; }   
        void Save();
    }
}
