using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIModels.Enums;
using GrupoESIDataAccess.Queries;

namespace GrupoESI.Pages.Tasks
{
    public class TaskEvidenceModel : PageModel
    {
        private readonly IQueries _queries;

        public TaskEvidenceModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public EvidenceTaskVM _taskModelVM { get; set; }
        public IActionResult OnGet(Guid taskId)
        {
            _taskModelVM = new EvidenceTaskVM();
            _taskModelVM.task = _queries.GetTaskIncludeLstMaterialPicturesQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals(taskId);

            if(_taskModelVM.task.Pictures == null)
            {
                _taskModelVM.task.Pictures = new List<Picture>();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostPictureAsync()
        {
            var tasklocal = _queries.GetTaskFirstOrDefaultWhereTaskIdEquals(_taskModelVM.task.Id);

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
                    _queries.SaveChanges();
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
