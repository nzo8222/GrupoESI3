using GrupoESIModels.Models;

using System.Collections.Generic;


namespace GrupoESIModels.ViewModels
{
    public class ManageEmployeesVM
    {
        public IList<EmployeeUser> EmployeeUsrLst { get; set; }
        public string EmployerId { get; set; }
    }
}
