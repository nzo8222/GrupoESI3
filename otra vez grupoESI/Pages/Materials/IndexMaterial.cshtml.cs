using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIDataAccess;

namespace GrupoESINuevo
{
    public class IndexMaterialModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexMaterialModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public MaterialVM _materialVM { get;set; }

        public async Task OnGetAsync(Guid taskId )
        {
            _materialVM = new MaterialVM();
            _materialVM.taskId = taskId;

            _materialVM.tareaLocal = await _context.Task
                                            .Include(t => t.ListMaterial)
                                            .Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetailsModel)
                                                    .ThenInclude(od => od.Order)
                                            .FirstOrDefaultAsync(t => t.Id == taskId);
            _materialVM.OrderDetailsId = _materialVM.tareaLocal.QuotationModel.OrderDetailsModel.Id;
            if(_materialVM.tareaLocal == null)
            {
                _materialVM.Material = new List<Material>();
            }
            else
            {
                _materialVM.Material = _materialVM.tareaLocal.ListMaterial;
            }
            _materialVM.OrderDetailsStatus = _materialVM.tareaLocal.QuotationModel.OrderDetailsModel.Status;

        }
    }
}
