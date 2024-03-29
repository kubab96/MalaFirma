﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class Zamowienie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa zamówienia jest wymagana")]
        [DisplayName("Nazwa zamówienia")]
        public string Nazwa { get; set; }
        [DisplayName("Data zamówienia")]
        [DataType(DataType.Date)]
        public DateTime DataZamowienia { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Wymagane jest wybranie klienta")]
        public int? KlientId { get; set; }
        [ValidateNever]
        public IEnumerable<Klient> Klient { get; set; }
        [DisplayName("Uwagi zamówienia")]
        public string? UwagiZamowienia { get; set; }
        public string? StatusZamowienia { get; set; }
    }
}
