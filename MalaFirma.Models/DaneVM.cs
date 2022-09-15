using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class DaneVM
    {
        public IEnumerable<Zamowienie> Zamowienia { get; set; }
        public IEnumerable<Zamowienie> Zamowienia2 { get; set; }
    }
}
