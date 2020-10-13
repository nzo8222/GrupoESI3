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
    public class IndexOrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexOrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderDetails> OrderDetailsList { get;set; }
        public string ServiceId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? serviceId = null)
        {
            if(serviceId == null)
            {
               
                return Page();
            }
            
            OrderDetailsList = await _context.OrderDetails
                                                          .Include(o => o.Order)
                                                          .Include(o => o.Service)
                                                                .ThenInclude(od => od.serviceType)
                                                          .Where( s =>s.Service.ID == serviceId)
                                                          .ToListAsync();
            
            return Page();
        }
    }
}
