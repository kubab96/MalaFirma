using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class KartaProjektu
    {
        [Key]
        public int Id { get; set; }
        public int procesId { get; set; }
        [ValidateNever]
        public Proces Proces { get; set; }
        public int przegladId { get; set; }
        [ValidateNever]
        public Przeglad Przeglad { get; set; }
    }
}
