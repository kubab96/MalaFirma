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
    public class SwiadectwoJakosci
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Numer świadectwa")]
        public string? NumerSwiadectwa { get; set; }
        [DisplayName("Wynik świadectwa")]
        [Required(ErrorMessage = "Wynik świadectwa jest wymagany")]
        public string WynikSwiadectwa { get; set; }

        public string? ZidentyfikowaneProblemy { get; set; }
        public string? PlanowaneDzialania { get; set; }
        [DisplayName("Data zakończenia świadectwa")]
        [DataType(DataType.DateTime)]
        public DateTime DataZakonczeniaSwiadectwa { get; set; }
        public int WymaganieId { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
    }
}
