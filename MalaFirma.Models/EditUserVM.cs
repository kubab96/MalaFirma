using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class EditUserVM
    {
        public EditUserVM()
        {
            Claims = new List<string>(); Roles = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string UlicaNumer { get; set; }
        public string KodPocztowy { get; set; }
        public string Rola { get; set; }
        public List<string> Claims { get; set; }
        public IList<string> Roles { get; set; }
    }
}
