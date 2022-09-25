using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.Models
{
    public class EditRoleVM
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
