using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class RysunekPrzewodnika
    {
        public int Id { get; set; }
        public string? Rysunek { get; set; }
        public string? NumerRysunku { get; set; }
        public int WymaganieId { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
    }
}
