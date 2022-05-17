using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class ZamowienieProcesVM
    {

        public Zamowienie Zamowienia { get; set; }
        public IEnumerable<Proces> Procesy { get; set; }
        public Proces Proces { get; set; }
    }
}
