using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GrupoESINuevo.Data;

using System.IO;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIModels.Enums;
using GrupoESIDataAccess;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class DetailsTaskModel : PageModel
    {
        private readonly IQueries _queries;

        public DetailsTaskModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public TaskPictureVM taskPicVM { get; set; }

        public IActionResult OnGetAsync(Guid? taskId)
        {
            if (taskId == null)
            {
                return NotFound();
            }
            taskPicVM = new TaskPictureVM();
            taskPicVM.taskModel = _queries.GetTaskIncludeLstMaterialPicturesQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals((Guid)taskId);

            if (taskPicVM == null)
            {
                return NotFound();
            }
            taskPicVM.OrderDetailsStatus = taskPicVM.taskModel.QuotationModel.OrderDetailsModel.Status;
            return Page();
        }
        public async Task<IActionResult> OnPostPicture()
        {
            var tasklocal = _queries.GetTaskFirstOrDefaultWhereTaskIdEquals(taskPicVM.taskModel.Id);
                

            if (taskPicVM.Upload == null)
            {
                return RedirectToPage("./DetailsTask", new { taskId = tasklocal.Id });
            }
            if (tasklocal.Pictures == null)
            {
                tasklocal.Pictures = new List<Picture>();
            }
            using (var memoryStream = new MemoryStream())
            {
                await taskPicVM.Upload.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 8097152)
                {
                    var file = new Picture()
                    {
                        PictureBytes = memoryStream.ToArray()
                    };
                    file.FechaDeSubida = DateTime.Now;
                    file.Tipo = PictureTypeEnum.Quotation;
                    tasklocal.Pictures.Add(file);
                    _queries.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            return RedirectToPage("./DetailsTask", new { taskId = tasklocal.Id });
        }
    }
}
