﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.Models
{
    public class Operacja
    {
        public int Id { get; set; }
        public string TrescOperacji { get; set; }
        public DateTime DataWykonania { get; set; } = DateTime.Now;
        public int ProcesId { get; set; }
        [ValidateNever]
        public Proces Proces { get; set; }
    }
}
