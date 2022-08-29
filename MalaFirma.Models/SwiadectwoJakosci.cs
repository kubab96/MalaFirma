using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
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
        public string? NumerSwiadectwa { get; set; }
        public string? WynikSwiadectwa { get; set; }
        public string? ZidentyfikowaneProblemy { get; set; }
        public string? PlanowaneDzialania { get; set; }
        public int? ZamowienieId { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        public int? WymaganieId { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
    }
}
