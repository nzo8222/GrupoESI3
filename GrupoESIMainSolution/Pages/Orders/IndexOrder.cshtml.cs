using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;

namespace GrupoESI
{
    public class IndexOrderModel : PageModel
    {
        private readonly IQueries _queries;
        public IndexOrderModel(IQueries queries)
        {
            _queries = queries;
        }
        public IList<OrderDetails> OrderDetailsList { get;set; }
        public string ServiceId { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? serviceId = null)
        {
            if(serviceId == null)
            {
                return Page();
            }
            OrderDetailsList = _queries.GetListOrderDetailsIncludeOrderServiceServiceTypeWhereServiceIdEqualsServiceID((Guid)serviceId);
            return Page();
        }
    }
}
