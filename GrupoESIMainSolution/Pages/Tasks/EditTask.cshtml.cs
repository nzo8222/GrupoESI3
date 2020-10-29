using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class EditModel : PageModel
    {
        private readonly IQueries _queries;

        public EditModel(IQueries queries)
        {
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
            TaskModel = _queries.GetTaskIncludeQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals((Guid)taskId);
            if (TaskModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TaskModel task = setAttributes();
            try
            {
                _queries.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = task.QuotationModel.OrderDetails.Id });
        }

        private TaskModel setAttributes()
        {
            var task = _queries.GetTaskIncludeQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals(TaskModel.Id);
            task.Name = TaskModel.Name;
            task.Description = TaskModel.Description;
            task.Duration = TaskModel.Duration;
            task.Cost = task.Cost - task.CostHandLabor + TaskModel.CostHandLabor;
            task.QuotationModel.OrderDetails.Cost = task.QuotationModel.OrderDetails.Cost - task.CostHandLabor + TaskModel.CostHandLabor;
            task.CostHandLabor = TaskModel.CostHandLabor;
            return task;
        }
    }
}
