using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class PytanieVM
    {
        public IEnumerable<Pytanie> Pytania { get; set; }
        public Pytanie Pytanie { get; set; }
    }
}
