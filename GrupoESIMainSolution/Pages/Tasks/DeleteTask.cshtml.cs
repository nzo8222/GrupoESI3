using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    public class DeleteModel : PageModel
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IQueries _queries;
        public DeleteModel(IQueries queries,
                           ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _queries = queries;
        }

        [BindProperty]
        public TaskModel TaskModel { get; set; }

        public IActionResult OnGetAsync(Guid? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }

            TaskModel = _queries.GetTaskIncludeQuotationOrderDetailsOrderFirstOrDefaultWhereTaskIdEquals((Guid)taskId);

            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(Guid? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }

            TaskModel = _queries.GetTaskIncludeLstMaterialPicturesQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals((Guid)taskId);
                
            TaskModel.QuotationModel.OrderDetails.Cost = TaskModel.QuotationModel.OrderDetails.Cost - TaskModel.Cost;
            if (TaskModel != null)
            {
                _taskRepository.Remove(TaskModel);
                _queries.SaveChanges();
            }

            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = TaskModel.QuotationModel.OrderDetails.Id });
        }
    }
}
