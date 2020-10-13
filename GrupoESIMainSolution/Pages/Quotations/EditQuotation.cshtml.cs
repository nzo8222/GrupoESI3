using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class EditQuotationModel : PageModel
    {

        private readonly IQueries _queries;

        public EditQuotationModel(IQueries queries)
        {
            _queries = queries;

        }

        [BindProperty]
        public Quotation Quotation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quotation =  _queries.GetQuotationWithOrderDetailsServiceApplicationUserWhereQuotationIdEqualsId((Guid)id);


            if (Quotation == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var quotationLocal = _queries.GetQuotationByQuotationId(Quotation.Id);
            quotationLocal.Description = Quotation.Description;
            try
            {
                await _queries.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
            return RedirectToPage("./IndexQuotation");
        }
    }
}
