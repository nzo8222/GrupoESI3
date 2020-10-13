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
    public class DetailsMaterialModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsMaterialModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid materialId)
        {
            if (materialId == null)
            {
                return NotFound();
            }
            Material = await _context.Material
                                            .Include(m => m.Task)
                                            .FirstOrDefaultAsync(m => m.Id == materialId);
            if (Material == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
