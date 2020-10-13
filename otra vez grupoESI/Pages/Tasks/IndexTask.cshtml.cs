using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess;

namespace GrupoESINuevo
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TaskModel> TaskList { get;set; }
        public TaskMaterialVM _taskMaterialVM { get; set; }
        public async Task OnGetAsync()
        {

            TaskList = await _context.Task
                                          .Include(t => t.QuotationModel)
                                            .ThenInclude(q => q.OrderDetailsModel)
                                                .ThenInclude(od => od.Order)
                                          .ToListAsync();
        }
    }
}
