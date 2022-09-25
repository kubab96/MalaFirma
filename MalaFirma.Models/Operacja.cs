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

namespace SimpleQMS.Models
{
    public class Operacja
    {
        public int Id { get; set; }
        [DisplayName("Treść operacji")]
        [Required(ErrorMessage = "Treść wykonanej operacji jest wymagana")]
        public string TrescOperacji { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy HH:mm}")]
        public DateTime DataWykonania { get; set; } = DateTime.Now;
        public int PrzewodnikPracyId { get; set; }
        [ValidateNever]
        public PrzewodnikPracy PrzewodnikPracy { get; set; }
    }
}
