using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.ViewModels;
using GrupoESIModels.Models;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class IndexMaterialModel : PageModel
    {
        private readonly IQueries _queries;
        public IndexMaterialModel(IQueries queries)
        {
            _queries = queries;
        }
        [BindProperty]
        public MaterialVM _materialVM { get;set; }

        public async Task OnGetAsync(Guid taskId )
        {
            LoadLstMaterialModel(taskId);
            if (_materialVM.tareaLocal == null)
            {
                _materialVM.Material = new List<Material>();
            }
            else
            {
                _materialVM.Material = _materialVM.tareaLocal.ListMaterial;
            }
            _materialVM.OrderDetailsStatus = _materialVM.tareaLocal.QuotationModel.OrderDetails.Status;
        }

        private void LoadLstMaterialModel(Guid taskId)
        {
            _materialVM = new MaterialVM();
            _materialVM.taskId = taskId;
            _materialVM.tareaLocal = _queries.GetTaskModelIncludeLstMaterialQuotationOrderDetailsOrderFirstOrDefaultTaskIdEqualsTaskId(taskId);
            _materialVM.OrderDetailsId = _materialVM.tareaLocal.QuotationModel.OrderDetails.Id;
        }
    }
}
