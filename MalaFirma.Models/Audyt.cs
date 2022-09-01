﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Audyt
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Temat audytu jest wymagany.")]
        public string Temat { get; set; }
        [Required(ErrorMessage = "Data audytu jest wymagana.")]
        [DisplayName("Data audytu")]
        public DateTime DataAudytu { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Opis audytu jest wymagany.")]
        public string Opis { get; set; }
        public string? Status { get; set; }
        public string? Uwagi { get; set; }

        [Required(ErrorMessage = "Rodzaj audytu jest wymagany.")]
        [DisplayName("Rodzaj audytu")]
        [EnumDataType(typeof(Rodzaj))]
        public Rodzaj RodzajAudytu { get; set; }
    }
    public enum Rodzaj
    {
        Wewnętrzny = 1,
        Zewnętrzny = 2
    }

}
