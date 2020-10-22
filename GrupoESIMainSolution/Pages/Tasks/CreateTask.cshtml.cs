using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class CreateModel : PageModel
    {
        private readonly IQueries _queries;

        public CreateModel(IQueries queries)
        {
            _queries = queries;
        }

        
        [BindProperty]
        public TaskQuotationVM _TaskQuotationVM { get; set; }
        public IActionResult OnGet(Guid orderDetailsId)
        {
            _TaskQuotationVM = new TaskQuotationVM(orderDetailsId);
            _TaskQuotationVM.TaskInfo = _queries.GetTaskIncludeQuotationOrderDetailsOrderFirstOrDefaultWhereOrderDetailsIdEquals(orderDetailsId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (_TaskQuotationVM.TaskLocal.Name == null)
            {
                return Page();
            }
            if(_TaskQuotationVM.TaskLocal.Description == null)
            {
                return Page();
            }
            _TaskQuotationVM.TaskLocal.Cost = _TaskQuotationVM.TaskLocal.CostHandLabor;
            var quotation = _queries.GetQuotationIncludeTaskOrderDetailsFirstOrDefaultWhereOrderDetailsEquals(_TaskQuotationVM.orderDetailsId);
                quotation.OrderDetailsModel.Cost = quotation.OrderDetailsModel.Cost + _TaskQuotationVM.TaskLocal.CostHandLabor;
                quotation.Tasks.Add(_TaskQuotationVM.TaskLocal);
             _queries.SaveChanges();
            return RedirectToPage("../Quotations/CreateQuotation", new { orderDetailsId = _TaskQuotationVM.orderDetailsId });
        }
    }
}
