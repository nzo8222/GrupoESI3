
using GrupoESIDataAccess;
using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIDataAccess.Queries
{
    public class Queries : IQueries
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ApplicationDbContext _context;
        public Queries(ApplicationDbContext context,
                        IQuotationRepository quotationRepository,
                        IOrderDetailsRepository orderDetailsRepository,
                        IOrderRepository orderRepository,
                        ITaskRepository taskRepository,
                        IMaterialRepository materialRepository,
                        IApplicationUserRepository applicationUserRepository,
                        IEmployeeRepository employeeRepository,
                        IServiceRepository serviceRepository)
        {
            _quotationRepository = quotationRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _orderRepository = orderRepository;
            _taskRepository = taskRepository;
            _materialRepository = materialRepository;
            _applicationUserRepository = applicationUserRepository;
            _employeeRepository = employeeRepository;
            _serviceRepository = serviceRepository;
            _context = context;
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Order GetOrderByOrderId(Guid orderId)
        {
            return _orderRepository.FirstOrDefault(o => o.Id == orderId);
                
        }
        public Quotation GetQuotationByQuotationId(Guid quotationId)
        {
            return _quotationRepository.FirstOrDefault(q => q.Id == quotationId);
        }
        public List<EmployeeUser> GetEmployeesAssosiatedToThisQuotation()
        {
            return (List<EmployeeUser>)_employeeRepository.GetAll(includeProperties:"QuotationLst");
                
        }

        public Quotation GetQuotationWithOrderDetailsServiceApplicationUserWhereQuotationIdEqualsId(Guid QuotationId)
        {
            Quotation q = new Quotation();
            q = _quotationRepository.FirstOrDefault(q => q.Id == QuotationId, includeProperties: "OrderDetailsModel");
            q.OrderDetailsModel.Service = _serviceRepository.FirstOrDefault(s => s.ID == q.OrderDetailsModel.ServiceId);
            q.OrderDetailsModel.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == q.OrderDetailsModel.Service.UserId);

            return q;
        }

        public Quotation GetQuotationWithOrderDetailsOrdersTasksListMaterialFirstOrDefault(Guid orderDetailsId)
        {
            Quotation q = new Quotation();
            q = _quotationRepository.FirstOrDefault(q => q.OrderDetailsId == orderDetailsId, includeProperties: "OrderDetailsModel");
            q.OrderDetailsModel.Order = _orderRepository.FirstOrDefault(s => s.Id == q.OrderDetailsModel.OrderId);
            q.Tasks = (List<TaskModel>)_taskRepository.GetAll(t => t.QuotationId == q.Id, includeProperties: "ListMaterial");
            return q;
                //_context.Quotation
                //                                                .Include(q => q.OrderDetailsModel)
                //                                                    .ThenInclude(q => q.Order)
                //                                                .Include(q => q.Tasks)
                //                                                    .ThenInclude(t => t.ListMaterial)
                //                                                    .FirstOrDefault(q => q.OrderDetailsModel.Id == orderDetailsId);
        }
        public OrderDetails GetOrderDetailsWithOrderServiceApplicationUser(Guid orderDetailsId)
        {

            OrderDetails od = new OrderDetails();
            od = _orderDetailsRepository.FirstOrDefault(od => od.Id == orderDetailsId, includeProperties: "Order,Service");
            od.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == od.Service.UserId);
            return od;
                //_context.OrderDetails
                //                                          .Include(od => od.Order)
                //                                          .Include(od => od.Service)
                //                                             .ThenInclude(s => s.ApplicationUser)
                //                                             .FirstOrDefault(od => od.Id == orderDetailsId);
        }
        public List<OrderDetails> GetListOrderDetailsWithOrderServiceApplicationUserFromSameUser(OrderDetails orderDetails)
        {
            List<OrderDetails> lstOd = new List<OrderDetails>();
            var odLocal = _orderDetailsRepository.FirstOrDefault(od => od.Id == orderDetails.Id, includeProperties: "Service");
            odLocal.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == odLocal.Service.UserId);
            lstOd = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => odLocal.Service.ApplicationUser.Id == orderDetails.Service.ApplicationUser.Id && od.Order.Id == orderDetails.Order.Id, includeProperties: "Order,Service");
            return lstOd;



                //_context.OrderDetails
                //                                                                .Include(od => od.Order)
                //                                                                .Include(od => od.Service)
                //                                                                     .ThenInclude(s => s.ApplicationUser)
                //                                                                     .Where(od => od.Service.ApplicationUser.Id == orderDetails.Service.ApplicationUser.Id && od.Order.Id == orderDetails.Order.Id).ToList();
        }

        public List<OrderDetails> GetOrderDetailsFromSameOrder(Guid orderId)
        {
            List<OrderDetails> lstOrderDetails = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => od.OrderId == orderId, includeProperties: "Order");
            return lstOrderDetails;
        }

        public List<OrderDetails> GetOrderDetailsIncludeOrderQuotationServiceThenIncludeApplicationUserWhereUserIdEquialsUserId(string userId)
        {
            Service service = _serviceRepository.FirstOrDefault(s => s.ApplicationUser.Id == userId, includeProperties: "ApplicationUser");
            List<OrderDetails> lstOrderDetails = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => od.ServiceId == service.ID, includeProperties: "Order,Quotation,Servicio");
            List<OrderDetails> lstOrderDetailsWithServiceApplicationUserEqualsToUserId = new List<OrderDetails>();
            foreach (var orderDetailsLocal in lstOrderDetails)
            {
                if(orderDetailsLocal.Service.ApplicationUser.Id == userId)
                {
                    lstOrderDetailsWithServiceApplicationUserEqualsToUserId.Add(orderDetailsLocal);
                }
            }

            return lstOrderDetailsWithServiceApplicationUserEqualsToUserId;
        }

        public Service GetServiceIncludeApplicationUserFirstOrDefault(Guid serviceId)
        {
            return _serviceRepository.FirstOrDefault(s => s.ID == serviceId, includeProperties: "ApplicationUser");
        }

        public Service GetServiceIncludeApplicationUserServiceTypeFirstOrDefault(Guid serviceId)
        {
            return _serviceRepository.FirstOrDefault(s => s.ID == serviceId, includeProperties: "ApplicationUser,serviceType");
        }


    }
}
