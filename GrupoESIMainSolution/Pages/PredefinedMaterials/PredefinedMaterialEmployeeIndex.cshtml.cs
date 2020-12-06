using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIModels;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.PredefinedMaterials
{
    public class PredefinedMaterialEmployeeIndexModel : PageModel
    {
        private readonly IQueries _queries;
        public PredefinedMaterialEmployeeIndexModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public PredefinedTaskMaterialIndexVM _predefinedTaskMaterialIndexVM { get; set; }
        public IActionResult OnGet(Guid? predefinedTaskId = null)
        {
            if (predefinedTaskId == null || predefinedTaskId == Guid.Empty)
            {
                return NotFound();
            }
            _predefinedTaskMaterialIndexVM = new PredefinedTaskMaterialIndexVM();
            PredefinedTask predefinedTaskLocal = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(predefinedTaskId);
            _predefinedTaskMaterialIndexVM.predefinedTaskCost = predefinedTaskLocal.Cost;
            _predefinedTaskMaterialIndexVM.predefinedTaskDescription = predefinedTaskLocal.Description;
            _predefinedTaskMaterialIndexVM.predefinedTaskName = predefinedTaskLocal.Name;
            _predefinedTaskMaterialIndexVM.serviceDescription = predefinedTaskLocal.Service.Description;
            _predefinedTaskMaterialIndexVM.serviceName = predefinedTaskLocal.Service.Name;
            _predefinedTaskMaterialIndexVM.predefinedTaskId = (Guid)predefinedTaskId;
            _predefinedTaskMaterialIndexVM.serviceId = predefinedTaskLocal.ServiceId;
            return Page();
        }
    }
}
