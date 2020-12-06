using System;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI
{
    public class CreatePredefinedTaskModel : PageModel
    {
        private readonly IQueries _queries;
        private readonly IPredefinedTaskRepository _predefinedTaskRepository;
        public CreatePredefinedTaskModel(IQueries queries,
                                         IPredefinedTaskRepository predefinedTaskRepository)
        {
            _predefinedTaskRepository = predefinedTaskRepository;
            _queries = queries;
        }
        [BindProperty]
        public CreatePredefinedTaskVM _predefinedTaskVM { get; set; }

        public IActionResult OnGet(Guid? serviceId = null)
        {

            if (serviceId == null)
            {
                return NotFound();
            }
            _predefinedTaskVM = new CreatePredefinedTaskVM();
            _predefinedTaskVM.serviceId = (Guid)serviceId;
            Service serviceLocal = _queries.GetServiceFirstOrDefault((Guid)serviceId);
            _predefinedTaskVM.ServiceName = serviceLocal.Name;
            _predefinedTaskVM.ServiceDescription = serviceLocal.Description;
            return Page();
        }
        public IActionResult OnPost()
        {
            PredefinedTask predefinedTaskslocal = new PredefinedTask();

            if (_predefinedTaskVM.serviceId == Guid.Empty)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                predefinedTaskslocal.ServiceId = _predefinedTaskVM.serviceId;

                predefinedTaskslocal.CostHandLabor = _predefinedTaskVM.CostHandLabor;
                predefinedTaskslocal.Cost = _predefinedTaskVM.CostHandLabor;
                predefinedTaskslocal.Description = _predefinedTaskVM.PredefinedTaskDescription;
                predefinedTaskslocal.Duration = _predefinedTaskVM.PredefinedTaskDuration;
                predefinedTaskslocal.Name = _predefinedTaskVM.PredefinedTaskName;
                _predefinedTaskRepository.Add(predefinedTaskslocal);
                _queries.SaveChanges();
                return RedirectToPage("PredefinedTaskIndex", new { serviceId = _predefinedTaskVM.serviceId });
            }
            return Page();
        }
    }
}
