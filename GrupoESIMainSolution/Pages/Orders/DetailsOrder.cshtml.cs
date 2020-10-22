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
    public class DetailsOrderModel : PageModel
    {
        private readonly IQueries _queries;

        public DetailsOrderModel(IQueries queries)
        {
            _queries = queries;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            Order = _queries.GetOrderIncludeOrderDetailsServiceApplicationUserFirstOrDefault((Guid)orderId);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
