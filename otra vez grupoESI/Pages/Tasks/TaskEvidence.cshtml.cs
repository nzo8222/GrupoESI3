using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GrupoESINuevo.Data;

using System.IO;

using Microsoft.EntityFrameworkCore;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIModels.Enums;
using GrupoESIDataAccess;

namespace GrupoESINuevo.Pages.Tasks
{
    public class TaskEvidenceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public TaskEvidenceModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public EvidenceTaskVM _taskModelVM { get; set; }
        public IActionResult OnGet(Guid taskId)
        {
            _taskModelVM = new EvidenceTaskVM();
            _taskModelVM.task = _context.Task
                                             .Include(t => t.Pictures)
                                             .Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetailsModel)
                                                    .ThenInclude(od => od.Order)
                                             .FirstOrDefault(t => t.Id == taskId);
            if(_taskModelVM.task.Pictures == null)
            {
                _taskModelVM.task.Pictures = new List<Picture>();
            }
            return Page();
        }

        

        
        public async Task<IActionResult> OnPostPictureAsync()
        {
            var tasklocal = _context.Task.FirstOrDefault(t => t.Id == _taskModelVM.task.Id);

            if (_taskModelVM.Upload == null)
            {
                return RedirectToPage("./DetailsTask", new { taskId = tasklocal.Id });
            }
            if (tasklocal.Pictures == null)
            {
                tasklocal.Pictures = new List<Picture>();
            }
            using (var memoryStream = new MemoryStream())
            {
                await _taskModelVM.Upload.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 8097152)
                {
                    var file = new Picture()
                    {
                        PictureBytes = memoryStream.ToArray()
                    };
                    file.FechaDeSubida = DateTime.Now;
                    file.Tipo = PictureTypeEnum.Evidence;
                    tasklocal.Pictures.Add(file);
                    //_dbContext.File.Add(file);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            return RedirectToPage("./TaskEvidence", new { taskId = tasklocal.Id });
        }
    }
}
