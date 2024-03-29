﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class PrzewodnikPracyVM
    {
        [ValidateNever]
        public IEnumerable<Wymaganie> Wymagania { get; set; }
        [ValidateNever]
        public Wymaganie Wymaganie { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        [ValidateNever]
        public PrzewodnikPracy PrzewodnikPracy { get; set; }
        [ValidateNever]
        public IEnumerable<PrzewodnikPracy> PrzewodnikiPracy { get; set; }
        [ValidateNever]
        public IEnumerable<Operacja> Operacje { get; set; }
        [ValidateNever]
        public Operacja Operacja { get; set; }
        [ValidateNever]
        public RysunekPrzewodnika RysunekPrzewodnika { get; set; }
        [ValidateNever]
        public SwiadectwoJakosci SwiadectwoJakosci { get; set; }
        [ValidateNever]
        public Przeglad Przeglad { get; set; }
        [ValidateNever]
        public IEnumerable<RysunekPrzewodnika> RysunekPrzewodnikow { get; set; }
        [ValidateNever]
        public IFormFile Rysunek { get; set; }
    }
}
