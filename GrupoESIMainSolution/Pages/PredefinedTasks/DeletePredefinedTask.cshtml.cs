using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels;
using GrupoESIModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrupoESI.Pages.PredefinedTasks
{
    public class DeletePredefinedTaskModel : PageModel
    {
        private readonly IQueries _queries;
        private readonly IPredefinedTaskRepository _predefinedTaskRepository;
        public DeletePredefinedTaskModel(IQueries queries,
                                         IPredefinedTaskRepository predefinedTaskRepository)
        {
            _predefinedTaskRepository = predefinedTaskRepository;
            _queries = queries;
        }
        [BindProperty]
        public CreatePredefinedTaskMaterialDescriptionVM _createPredefinedTaskMaterialDescriptionVM { get; set; }
        public IActionResult OnGet(string predefinedTaskId = null)
        {
            _createPredefinedTaskMaterialDescriptionVM = new CreatePredefinedTaskMaterialDescriptionVM();
            Guid id = Guid.Parse(predefinedTaskId);
            PredefinedTask predefinedTask = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(id);
            _createPredefinedTaskMaterialDescriptionVM.serviceName = predefinedTask.Service.Name;
            _createPredefinedTaskMaterialDescriptionVM.serviceDescription = predefinedTask.Service.Description;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskDescription = predefinedTask.Description;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskCost = predefinedTask.CostHandLabor;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskDuration = predefinedTask.Duration;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskName = predefinedTask.Name;
            _createPredefinedTaskMaterialDescriptionVM.predefinedTaskId = predefinedTask.PredefinedTaskId;
            _createPredefinedTaskMaterialDescriptionVM.serviceId = predefinedTask.ServiceId;
            return Page();
        }
        public IActionResult OnPost()
        {
            PredefinedTask predefinedTask = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(_createPredefinedTaskMaterialDescriptionVM.predefinedTaskId);
            _predefinedTaskRepository.Remove(predefinedTask);
            _queries.SaveChanges();
            return RedirectToPage("PredefinedTaskIndex", new { serviceId = predefinedTask.ServiceId });
        }
    }
}
