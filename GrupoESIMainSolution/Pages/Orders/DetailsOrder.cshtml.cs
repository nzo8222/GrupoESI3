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

namespace GrupoESINuevo
{
    public class DetailsOrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsOrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                                        .Include(o => o.LstOrderDetails)
                                            .ThenInclude(o => o.Service)
                                                .ThenInclude(s => s.ApplicationUser)
                                        .FirstOrDefaultAsync(m => m.Id == orderId);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
