using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class PrzegladVM
    {
        public IEnumerable<Pytanie> Pytania { get; set; }
        public IEnumerable<Odpowiedz> Odpowiedzi { get; set; }
        public IEnumerable<Zamowienie> Zamowienia{ get; set; }
        public Odpowiedz Odpowiedz { get; set; }
        public Pytanie Pytanie { get; set; }
        public Zamowienie Zamowienie { get; set; }
    }
}
