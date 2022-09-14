using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage = "Wymagane jest podanie początkowej daty ważności obsługi metrologicznej.")]
        [DisplayName("Data obsługi")]
        public DateTime DataObslugi { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Wymagane jest podanie daty ważności obsługi metrologicznej.")]
        [DisplayName("Data ważnosci")]
        public DateTime DataWaznosci { get; set; }
        [ValidateNever]
        public int NarzedzieId { get; set; }
        [ValidateNever]
        public Narzedzie Narzedzie { get; set; }    
    }
}
