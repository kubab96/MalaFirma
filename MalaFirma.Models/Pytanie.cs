using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Pytanie
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
    }
}
