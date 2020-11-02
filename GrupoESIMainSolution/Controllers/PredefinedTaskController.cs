using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GrupoESIModels.ViewModels;
using GrupoESIModels;

namespace GrupoESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredefinedTaskController : Controller
    {
        private readonly IQueries _queries;
        public PredefinedTaskController(IQueries queries)
        {
            _queries = queries;
        }
        [HttpGet]
        [Route("GetPredefinedTaskLst")]
        public IActionResult GetOrderList(string serviceId)
        {
            List<PredefinedTaskIndexVM> predefinedTaskVMLst = SetAttributesToPredefinedTask(serviceId);
            return Json(new { data = predefinedTaskVMLst });
        }

        private List<PredefinedTaskIndexVM> SetAttributesToPredefinedTask(string serviceId)
        {
            var predefinedTaskVMLst = new List<PredefinedTaskIndexVM>();
            List<PredefinedTask> predefinedTask = _queries.GetAllPredefinedTaskWhereServiceIdEquals(serviceId);
            for (int i = 0; i < predefinedTask.Count; i++)
            {
                var predefinedTaskLocal = new PredefinedTaskIndexVM();
                predefinedTaskLocal.predefinedTaskId = predefinedTask[i].Id.ToString();
                predefinedTaskLocal.serviceId = predefinedTask[i].ServiceId.ToString();
                predefinedTaskLocal.predefinedTaskCost = predefinedTask[i].Cost.ToString();
                predefinedTaskLocal.predefinedTaskCostHandLabor = predefinedTask[i].CostHandLabor.ToString();
                predefinedTaskLocal.predefinedTaskDescription = predefinedTask[i].Description;
                predefinedTaskLocal.predefinedTaskDuration = predefinedTask[i].Duration.ToString();
                predefinedTaskVMLst.Add(predefinedTaskLocal);
            }

            return predefinedTaskVMLst;
        }
    }
}
