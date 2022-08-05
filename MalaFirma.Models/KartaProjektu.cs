using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class KartaProjektu
    {
        [Key]
        public int Id { get; set; }
        public int? PrzegladId { get; set; }
        public Przeglad? Przeglad { get; set; }
        public int? ZamowienieId { get; set; }
        public Zamowienie? Zamowienie { get; set; }
        public string DodatkoweInformacje { get; set; }
        public string DodatkoweUwagi { get; set; }
    }
}
