using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class TypNarzedzia
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Typ narzędzia jest wymagany.")]
        [DisplayName("Typ narzędzia")]
        public string NazwaTypu { get; set; }
    }
}
