﻿using System;
using System.Collections.Generic;
using System.Linq;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels.Enums;
using GrupoESIModels.Models;
using GrupoESIModels.ViewModels;
using GrupoESIUtility;
using Microsoft.AspNetCore.Mvc;

namespace GrupoESI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageOrdersController : Controller
    {
        private readonly IQuotationRepository _quoationRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IQueries _queries;
            public ManageOrdersController(IQueries queries,
                                          IQuotationRepository quotationRepository,
                                          IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _quoationRepository = quotationRepository;
            _queries = queries;
        }
        [HttpGet]
        [Route("GetOrderList")]
        public IActionResult GetOrderList()
        {
            var orderList = _queries.GetAllLstOrderIncludeLstOrderDetailsServiceServiceTypeToList();
            var orderVM = new List<OrderAdminIndexVM>();
            for (int i = 0; i < orderList.Count; i++)
            {
                var orderLocal = new OrderAdminIndexVM();
                orderLocal.orderId = orderList[i].Id.ToString();
                orderLocal.Concept = orderList[i].Concepto;
                orderLocal.Address = orderList[i].Direccion;
                orderLocal.Date = orderList[i].OrderDate.ToString();
                orderLocal.StateOfTheOrder = orderList[i].EstadoDelPedido;
                orderVM.Add(orderLocal);
            }
            return Json(new { data = orderVM });
        }
        [HttpPost]
        [Route("PostManageOrders")]
        public IActionResult PostNewOrders([FromBody] PostManageOrdersVM _pmovm)
        {
            List<string> serviceIdList = _pmovm.idService.Split(',').ToList();
            
            foreach (var serviceId in serviceIdList)
            {
                OrderDetails _OrderDetailsNueva = new OrderDetails();
                var quotationLocal = new Quotation();
                quotationLocal.Tasks = new List<TaskModel>();
                _OrderDetailsNueva.Order = _queries.GetOrderByOrderId(_pmovm.orderId);
                Guid id = Guid.Parse(serviceId);
                _OrderDetailsNueva.Service = _queries.GetServiceFirstOrDefault(id);
                var quotation = _queries.GetQuotationIncludeOrderTaskListMaterialWhereOrderIdEqualsOrderId(_pmovm.orderId);
                var pics = _queries.GetQuotationIncludeOrderDetailsOrderTaskPicturesFirstOrDefaultWhereOrderIdEquals(_pmovm.orderId);

                for (int i = 0; i < quotation.Tasks.Count; i++)
                {
                    var _taskLocal = new TaskModel();
                    
                    for (int f = 0; f < quotation.Tasks[i].ListMaterial.Count; f++)
                    {
                        if(_taskLocal.ListMaterial == null)
                        {
                            _taskLocal.ListMaterial = new List<Material>();
                        }
                        var mat = new Material();
                        mat.Description = quotation.Tasks[i].ListMaterial[f].Description;
                        mat.Name = quotation.Tasks[i].ListMaterial[f].Name;
                        mat.Price = 0;
                        _taskLocal.ListMaterial.Add(mat);
                    }

                    if(_taskLocal.Pictures == null)
                    {
                        _taskLocal.Pictures = new List<Picture>();
                    }

                        for (int e = 0; e < pics.Tasks[i].Pictures.Count; e++)
                    {
                        var picLocal = new Picture();
                        picLocal.PictureBytes = pics.Tasks[i].Pictures[e].PictureBytes;
                        picLocal.Tipo = PictureTypeEnum.Quotation;
                        _taskLocal.Pictures.Add(picLocal);
                    }
                    _taskLocal.Name = quotation.Tasks[i].Name;
                    _taskLocal.Duration = quotation.Tasks[i].Duration;
                    _taskLocal.Description = quotation.Tasks[i].Description;
                    quotationLocal.Tasks.Add(_taskLocal);
                }

                quotationLocal.Description = quotation.Description;

                quotationLocal.OrderDetails = _OrderDetailsNueva;
                quotationLocal.ProviderArrivalDate = DateTime.Now;
                _OrderDetailsNueva.Status = SD.EstadoCotizando;
                _quoationRepository.Add(quotationLocal);
                _orderDetailsRepository.Add(_OrderDetailsNueva);
            }
            try
            {
                _queries.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }

        [HttpPost]
        [Route("PostServiceToOrder")]
        public IActionResult PostServiceToOrder([FromBody] PostServiceToOrderVM serviceToOrderVM)
        {

            List<string> serviceIdList = serviceToOrderVM.serviceId.Split(',').ToList();


            foreach (var serviceId in serviceIdList)
            {

                var od = new OrderDetails();
                od.Order = new Order();

                var orderLocal = _queries.GetOrderByOrderId(serviceToOrderVM.OrderId);


                od.Order = orderLocal;

                Guid id = Guid.Parse(serviceId);
                od.Service = _queries.GetServiceFirstOrDefault(id);

                od.Cost = 0;

                var quotationLocal = new Quotation();

                quotationLocal.OrderDetails = od;

                quotationLocal.Tasks = new List<TaskModel>();

                od.Status = SD.EstadoSinCotizar;

                _orderDetailsRepository.Add(od);
                _quoationRepository.Add(quotationLocal);
                try
                {
                    _queries.SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
            return Ok();
        }
        [HttpPost]
        [Route("PostDeletePictures")]
        public IActionResult PostDeletePictures([FromBody] DeletePictureVM deletePictureVM)
        {
            List<string> result = deletePictureVM.deletePicturesId.Split(',').ToList();
            var task = _queries.GetTaskIncludePicturesFirstOrDefaultWhereTaskIdEquals(deletePictureVM.taskId);

            foreach (var item in result)
            {
                var pic = task.Pictures.Find(p => p.PictureId.ToString() == item);
                task.Pictures.Remove(pic);
            }
            try
            {
                _queries.SaveChanges();
            }catch(Exception ex)
            {

            }
            
            return Ok();
        }

        [HttpPost]
        [Route("PostAssignQuotation")]
        public IActionResult PostAssignQuotation([FromBody] PostAssignQuotationVM _PostAssignQuotationVM)
        {
            var quotation = _queries.GetQuotationByQuotationId(_PostAssignQuotationVM.idQuotation);
            var orderDetails = _queries.GetOrderDetailsIncludeOrderServiceApplicationUserFirstOrDefaultOrderDetailsIdEqualsOrderDetailsId(_PostAssignQuotationVM.idOrderDetails);
            var orders = _queries.GetLstOrderDetailsIncludeOrderServiceServiceTypeWhereOrderIdEqualsOrderId(orderDetails.Order.Id);
                

            foreach (var item in orders)
            {
                if(item != orderDetails)
                {
                    item.Status = SD.EstadoRechazado;
                }
                else
                {
                    item.Status = SD.EstadoAsignado;
                    item.Order.EstadoDelPedido = SD.EstadoAsignado;
                }
            }
            try
            {
                _queries.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }
        }
}