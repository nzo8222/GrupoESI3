using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESIDataAccess.Queries;

namespace GrupoESINuevo
{
    public class IndexModel : PageModel
    {
        private readonly IQueries _queries;

        public IndexModel(IQueries queries)
        {
            _queries = queries;
        }

        public IList<TaskModel> TaskList { get;set; }
        public TaskMaterialVM _taskMaterialVM { get; set; }
        public async Task OnGetAsync()
        {
            TaskList = _queries.GetAllTaskLstIncludeQuotationOrderDetailsOrder();
        }
    }
}
