using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class EmployeeIndexVM
    {
        public EmployeeUser EmployeeLocal { get; set; }
        public List<OrderDetails> orderDetailsList { get; set; }
    }
}
