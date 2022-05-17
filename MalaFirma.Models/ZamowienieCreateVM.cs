using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class ZamowienieCreateVM
    {
        public Zamowienie Zamowienia { get; set; }
        public Proces Procesy { get; set; }
        public int ZamowienieId {get; set;}
        public IEnumerable<Zamowienie> Zamowieniaa { get; set; }
    }
}
