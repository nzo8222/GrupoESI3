using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;

namespace GrupoESI
{
    public class EditMaterialModel : PageModel
    {
        private readonly IQueries _queries;

        public EditMaterialModel(IQueries queries)
        {
            _queries = queries;
        }

        [BindProperty]
        public Material Material { get; set; }

        public IActionResult OnGetAsync(Guid materialId)
        {
            if (materialId == null)
            {
                return NotFound();
            }

            Material = _queries.GetMaterialIncludeTaskFirstOrDefaultIdEqualsMaterialsId(materialId);

            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (Material.Description == "")
            {
                return Page();
            }
            if (Material.Name == "")
            {
                return Page();
            }
            Material mat = EditMaterial();
            try
            {
                _queries.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return RedirectToPage("./IndexMaterial", new { taskId = mat.Task.Id });
        }

        private Material EditMaterial()
        {
            var mat = _queries.GetMaterialIncludeTaskFirstOrDefaultIdEqualsMaterialsId(Material.Id);
            var task = _queries.GetTaskIncludeQuotationOrderDetailsFirstOrDefault(mat.TaskModelId);
            task.Cost = task.Cost - (int)mat.Price + (int)Material.Price;
            task.QuotationModel.OrderDetails.Cost = task.QuotationModel.OrderDetails.Cost - (int)mat.Price + (int)Material.Price;
            mat.Name = Material.Name;
            mat.Price = Material.Price;
            mat.Description = Material.Description;
            return mat;
        }
    }
}
