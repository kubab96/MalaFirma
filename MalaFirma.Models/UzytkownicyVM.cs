using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class UzytkownicyVM
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
