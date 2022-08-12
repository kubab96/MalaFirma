using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Proces
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa procesu do wykonania jest wymagana")]
        [DisplayName("Nazwa procesu")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Opis procesu do wykonania jest wymagany")]
        public string Opis { get; set; }
        public int Ilosc { get; set; }
        public string Material { get; set; }
        public int ZamowienieId { get; set; }
        public Zamowienie Zamowienie { get; set; }
        public int? KartaProjektuId { get; set; }
        public Zamowienie KartaProjektu { get; set; }
    }
}
