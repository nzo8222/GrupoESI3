using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;

namespace GrupoESINuevo
{
    public class DeleteMaterialModel : PageModel
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IQueries _queries;
        public DeleteMaterialModel(IQueries queries,
                                   IMaterialRepository material)
        {
            _queries = queries;
            _materialRepository = material;
        }

        [BindProperty]
        public DeleteMaterialVM DeleteMaterialVM { get; set; }

        public IActionResult OnGetAsync(Guid? materialId)
        {
            if (materialId == null)
            {
                return NotFound();
            }
            DeleteMaterialVM = new DeleteMaterialVM();
            DeleteMaterialVM.material = _queries.GetMaterialIncludeTaskFirstOrDefaultIdEqualsMaterialsId((Guid)materialId);
            if (DeleteMaterialVM == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync()
        {

            if (DeleteMaterialVM.material.Id == null)
            {
                return NotFound();
            }
            UpdateOrderDetailsCostAndDeleteMaterial();
            return RedirectToPage("./IndexMaterial", new { taskId = DeleteMaterialVM.material.Task.Id });
        }

        private void UpdateOrderDetailsCostAndDeleteMaterial()
        {
            DeleteMaterialVM.material = _queries.GetMaterialIncludeTaskFirstOrDefaultIdEqualsMaterialsId(DeleteMaterialVM.material.Id);
            if (DeleteMaterialVM.material.Task != null)
            {
                var tarea = _queries.GetTaskModelIncludeLstMaterialQuotationOrderDetailsOrderFirstOrDefaultTaskIdEqualsTaskId(DeleteMaterialVM.material.Task.Id);
                tarea.QuotationModel.OrderDetailsModel.Cost = tarea.QuotationModel.OrderDetailsModel.Cost - DeleteMaterialVM.material.Price;
                tarea.Cost = tarea.Cost - DeleteMaterialVM.material.Price;
                _materialRepository.Remove(DeleteMaterialVM.material);
                _queries.SaveChanges();
            }
        }
    }
}
