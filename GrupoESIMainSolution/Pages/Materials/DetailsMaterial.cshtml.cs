using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;

namespace GrupoESI
{
    public class DetailsMaterialModel : PageModel
    {
        private readonly IQueries _queries;
        public DetailsMaterialModel(IQueries queries)
        {
            _queries = queries;
        }

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
    }
}
