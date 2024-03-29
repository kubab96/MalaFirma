﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class Szkolenie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Temat szkolenia jest wymagany.")]
        public string Temat { get; set; }
        [Required(ErrorMessage = "Data rozpoczęcia szkolenia jest wymagana.")]
        [DisplayName("Data rozpoczęcia")]
        [DataType(DataType.Date)]
        public DateTime DataRozpoczecia { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Data zakończenia szkolenia jest wymagana.")]
        [DisplayName("Data zakończenia")]
        [DataType(DataType.Date)]
        public DateTime DataZakonczenia { get; set; } = DateTime.Now;
        public string? Status { get; set; }
        public string? Uwagi { get; set; }
        [Required(ErrorMessage = "Rodzaj szkolenia jest wymagany.")]
        [DisplayName("Rodzaj szkolenia")]
        [EnumDataType(typeof(RodzajSzkolenia))]
        public RodzajSzkolenia RodzajSz { get; set; }
    }
    public enum RodzajSzkolenia
    {
        BHP = 1,
        Jakościowe = 2,
        Techniczne = 3,
    }
}

