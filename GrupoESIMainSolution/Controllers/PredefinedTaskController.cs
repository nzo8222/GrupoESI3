using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoESIDataAccess.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GrupoESIModels.ViewModels;
using GrupoESIModels;
using GrupoESIModels.ViewModels.PredefinedTaskWithQuotationId;

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
        [HttpPost]
        [Route("AddPredefinedTaskToQuotation")]
        public IActionResult AddPredefinedTaskToQuotation([FromBody] AddPredefinedTaskToQuotation postPredefinedTaskToQuotationVM)
        {
            if (postPredefinedTaskToQuotationVM.predefinedTaskId == "" || postPredefinedTaskToQuotationVM.quotationId == "")
            {
                return NotFound();
            }
            Guid predefinedTaskId = Guid.Parse(postPredefinedTaskToQuotationVM.predefinedTaskId);
            Guid quotationId = Guid.Parse(postPredefinedTaskToQuotationVM.quotationId);
            PredefinedTask predefinedTask = _queries.GetPredefinedTaskIncludeServiceLstPredefinedMaterialWherePredefinedTaskIdEquals(predefinedTaskId);
            GrupoESIModels.Models.Quotation quotation = _queries.GetQuotationIncludeTaskMaterialWhereQuotationIdEquals(quotationId);
            GrupoESIModels.Models.TaskModel taskModel = new GrupoESIModels.Models.TaskModel();
            taskModel.ListMaterial = new List<GrupoESIModels.Models.Material>();
            for (int i = 0; i < predefinedTask.ListPredefinedMaterial.Count(); i++)
            {
                GrupoESIModels.Models.Material material = new GrupoESIModels.Models.Material();
                material.Description = predefinedTask.ListPredefinedMaterial[i].Description;
                material.Name = predefinedTask.ListPredefinedMaterial[i].Name;
                material.Price = predefinedTask.ListPredefinedMaterial[i].Price;
                taskModel.ListMaterial.Add(material);
            }
            taskModel.Name = predefinedTask.Name;
            taskModel.Cost = predefinedTask.Cost;
            taskModel.CostHandLabor = predefinedTask.CostHandLabor;
            taskModel.Description = predefinedTask.Description;
            taskModel.Duration = predefinedTask.Duration;
            
            quotation.Tasks.Add(taskModel);
            _queries.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("GetPredefinedTaskLstForQuotation")]
        public IActionResult PostAssignPredefinedTaskToQuotation([FromBody] PostPredefinedTaskToQuotationVM postPredefinedTaskToQuotationVM)
        {
            if (postPredefinedTaskToQuotationVM.serviceId == "" || postPredefinedTaskToQuotationVM.quotationId == "")
            {
                return NotFound();
            }
            Guid id = Guid.Parse(postPredefinedTaskToQuotationVM.serviceId);
            List<PredefinedTaskWithQuotationId> LstPredefinedTaskWithQuotationId = new List<PredefinedTaskWithQuotationId>();
            List<PredefinedTaskIndexVM> predefinedTaskVMLst = SetAttributesToPredefinedTask(postPredefinedTaskToQuotationVM.serviceId);
            for (int i = 0; i < predefinedTaskVMLst.Count(); i++)
            {
                PredefinedTaskWithQuotationId PredefinedTaskWithQuotationIdLocal = new PredefinedTaskWithQuotationId();
                PredefinedTaskWithQuotationIdLocal.predefinedTaskCost = predefinedTaskVMLst[i].predefinedTaskCost;
                PredefinedTaskWithQuotationIdLocal.predefinedTaskDescription = predefinedTaskVMLst[i].predefinedTaskDescription;
                PredefinedTaskWithQuotationIdLocal.predefinedTaskDuration = predefinedTaskVMLst[i].predefinedTaskDuration;
                PredefinedTaskWithQuotationIdLocal.predefinedTaskId = predefinedTaskVMLst[i].predefinedTaskId;
                PredefinedTaskWithQuotationIdLocal.predefinedTaskName = predefinedTaskVMLst[i].predefinedTaskName;
                PredefinedTaskWithQuotationIdLocal.quotationId = postPredefinedTaskToQuotationVM.quotationId;
                LstPredefinedTaskWithQuotationId.Add(PredefinedTaskWithQuotationIdLocal);
            }
            return Ok(new { data = LstPredefinedTaskWithQuotationId });
        }
        [HttpGet]
        [Route("GetPredefinedTaskMaterialLst")]
        public IActionResult GetPredefinedTaskMaterialList(string predefinedTaskId)
        {
            Guid predefinedTaskIdLocal = Guid.Parse(predefinedTaskId);
            List<PredefinedMaterial> predefinedMaterialLst = _queries.GetAllPredefinedTaskMaterialWherePredefinedTaskIdEquals(predefinedTaskIdLocal);
            List<PredefinedTaskMaterialVM> predefinedTaskMaterialVMLst = new List<PredefinedTaskMaterialVM>();
            foreach (var predefinedMaterial in predefinedMaterialLst)
            {
                PredefinedTaskMaterialVM predefinedTaskMaterialVMLocal = new PredefinedTaskMaterialVM();
                predefinedTaskMaterialVMLocal.materialName = predefinedMaterial.Name;
                predefinedTaskMaterialVMLocal.materialDescription = predefinedMaterial.Description;
                predefinedTaskMaterialVMLocal.materialCost = predefinedMaterial.Price.ToString();
                predefinedTaskMaterialVMLocal.predefinedMaterialId = predefinedMaterial.PredefinedMaterialId.ToString();
                predefinedTaskMaterialVMLst.Add(predefinedTaskMaterialVMLocal);
            }
            return Json(new {data = predefinedTaskMaterialVMLst });
        }
        [HttpGet]
        [Route("GetPredefinedTaskLst")]
        public IActionResult GetPredefinedTaskList(string serviceId)
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
                predefinedTaskLocal.predefinedTaskId = predefinedTask[i].PredefinedTaskId.ToString();
                predefinedTaskLocal.predefinedTaskName = predefinedTask[i].Name;
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
