using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class ObslugaMetrologiczna
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataObslugi { get; set; } = DateTime.Now;
        public DateTime DataWaznosci { get; set; }
        [ValidateNever]
        public int NarzedzieId { get; set; }
        [ValidateNever]
        public Narzedzie Narzedzie { get; set; }    
    }
}
