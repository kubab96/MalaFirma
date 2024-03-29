﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class KartaProjektu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? PrzegladId { get; set; }
        public Przeglad? Przeglad { get; set; }
        public int ZamowienieId { get; set; }
        [ValidateNever]
        public Zamowienie Zamowienie { get; set; }
        public string? DodatkoweInformacje { get; set; }
        public string? NumerKarty { get; set; }
        public string? DodatkoweUwagi { get; set; }
    }
}
