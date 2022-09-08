using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public class PrzewodnikPracy
    {
        [Key]
        public int Id { get; set; }
        public string? NumerPrzewodnika { get; set; }
        public string? WynikPrzewodnika { get; set; }
        [DisplayName("Data zakończenia przewodnika")]
        [DataType(DataType.DateTime)]
        public DateTime DataZakonczeniaPrzewodnika { get; set; }
        public string? ZidentyfikowaneProblemy { get; set; }
        public string? PlanowaneDzialania { get; set; }
        public string? Rysunek { get; set; }
        public string? NumerRysunku { get; set; }
        public int ZamowienieId { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        public int? WymaganieId { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }

    }
}
