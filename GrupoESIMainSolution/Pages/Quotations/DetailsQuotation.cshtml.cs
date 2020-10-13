using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESIModels.Models;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class DetailsQuotationModel : PageModel
    {
        private readonly IQueries _queries;

        public DetailsQuotationModel(IQueries queries)
        {
            _queries = queries;
        }

        public Quotation Quotation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quotation = _queries.GetQuotationWithOrderDetailsServiceApplicationUserWhereQuotationIdEqualsId((Guid)id);

            if (Quotation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
