using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;

using Microsoft.EntityFrameworkCore;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class CreateMaterialModel : PageModel
    {

        private readonly IQueries _queries;
        public CreateMaterialModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public TaskMaterialVM _TaskMaterialVM { get; set; }
        public IActionResult OnGet(Guid taskId)
        {
            if (taskId == null)
            {
                return Page();
            }
            SetMaterialAttributes(taskId);
            return Page();
        }
        private void SetMaterialAttributes(Guid taskId)
        {
            _TaskMaterialVM = new TaskMaterialVM()
            {
                MaterialModel = new Material(),
                TareaModel = _queries.GetTaskIncludeQuotationOrderDetailsFirstOrDefault(taskId),
                taskId = taskId

            };
            _TaskMaterialVM.orderDetailsId = _TaskMaterialVM.TareaModel.QuotationModel.OrderDetailsModel.Id;
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()

        {
            if (_TaskMaterialVM.MaterialModel.Name == "")
            {
                return Page();
            }
            if (_TaskMaterialVM.MaterialModel.Description == "")
            {
                return Page();
            }
            TaskModel tareaModel = SetAttributes();
            saveChanges();
            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = tareaModel.QuotationModel.OrderDetailsModel.Id });
        }
        private void saveChanges()
        {
            try
            {
                _queries.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private TaskModel SetAttributes()
        {
            var tareaModel = _queries.GetTaskModelIncludeLstMaterialQuotationOrderDetailsOrderFirstOrDefaultTaskIdEqualsTaskId(_TaskMaterialVM.taskId);
            if (tareaModel.ListMaterial == null)
            {
                tareaModel.ListMaterial = new List<Material>();
            }
            _TaskMaterialVM.MaterialModel.TaskModelId = tareaModel.Id;
            tareaModel.ListMaterial.Add(_TaskMaterialVM.MaterialModel);
            tareaModel.Cost = tareaModel.Cost + _TaskMaterialVM.MaterialModel.Price;
            tareaModel.QuotationModel.OrderDetailsModel.Cost = tareaModel.QuotationModel.OrderDetailsModel.Cost + _TaskMaterialVM.MaterialModel.Price;
            return tareaModel;
        }
    }
}


