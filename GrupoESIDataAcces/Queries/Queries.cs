using GrupoESIDataAccess.Repository.IRepository;
using GrupoESIModels;
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
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly ApplicationDbContext _context;
        private readonly IPictureRepository _pictureRepository;
        public Queries(ApplicationDbContext context,
                        IQuotationRepository quotationRepository,
                        IOrderDetailsRepository orderDetailsRepository,
                        IOrderRepository orderRepository,
                        ITaskRepository taskRepository,
                        IMaterialRepository materialRepository,
                        IApplicationUserRepository applicationUserRepository,
                        IEmployeeRepository employeeRepository,
                        IServiceRepository serviceRepository,
                        IPictureRepository pictureRepository,
                        IServiceTypeRepository serviceTypeRepository)
        {
            _quotationRepository = quotationRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _orderRepository = orderRepository;
            _taskRepository = taskRepository;
            _materialRepository = materialRepository;
            _applicationUserRepository = applicationUserRepository;
            _employeeRepository = employeeRepository;
            _serviceRepository = serviceRepository;
            _pictureRepository = pictureRepository;
            _serviceTypeRepository = serviceTypeRepository;
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
            q = _quotationRepository.FirstOrDefault(q => q.Id == QuotationId, includeProperties: "OrderDetails");
            q.OrderDetails.Service = _serviceRepository.FirstOrDefault(s => s.ID == q.OrderDetails.ServiceId);
            q.OrderDetails.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == q.OrderDetails.Service.UserId);
            return q;
        }
        public Quotation GetQuotationIncludeOrderDetailsOrdersEmployeeTasksListMaterialPicturesFirstOrDefault(Guid orderDetailsId)
        {

            var orderDetails = _context.OrderDetails
                                                    .Include(o => o.Quotation)
                                                    .Include(o => o.Order)
                                                    .FirstOrDefault(o => o.Id == orderDetailsId);
            var quotation = _context.Quotation
                                        .Include(q => q.Employee)
                                        .Include(q => q.Tasks)
                                             .ThenInclude(t => t.ListMaterial)
                                        .FirstOrDefault(q => q.Id == orderDetails.Quotation.Id);
            quotation.OrderDetails = orderDetails;
            foreach (var task in quotation.Tasks)
            {
                task.Pictures = _context.Pictures.Where(p => p.TaskModelId == task.Id).ToList();
            }
            return quotation;
        }
        public OrderDetails GetOrderDetailsWithOrderServiceApplicationUser(Guid orderDetailsId)
        {
            OrderDetails od = new OrderDetails();
            od = _orderDetailsRepository.FirstOrDefault(od => od.Id == orderDetailsId, includeProperties: "Order,Service");
            od.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == od.Service.UserId);
            return od;
        }
        public List<OrderDetails> GetListOrderDetailsWithOrderServiceApplicationUserFromSameUser(OrderDetails orderDetails)
        {
            List<OrderDetails> lstOd = new List<OrderDetails>();
            var odLocal = _orderDetailsRepository.FirstOrDefault(od => od.Id == orderDetails.Id, includeProperties: "Service");
            odLocal.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == odLocal.Service.UserId);
            lstOd = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => odLocal.Service.ApplicationUser.Id == orderDetails.Service.ApplicationUser.Id && od.Order.Id == orderDetails.Order.Id, includeProperties: "Order,Service");
            return lstOd;
        }

        public List<OrderDetails> GetOrderDetailsFromSameOrder(Guid orderId)
        {
            List<OrderDetails> lstOrderDetails = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => od.OrderId == orderId, includeProperties: "Order");
            return lstOrderDetails;
        }

        public List<OrderDetails> GetOrderDetailsIncludeOrderQuotationServiceThenIncludeApplicationUserWhereUserIdEquialsUserId(string userId)
        {
            ApplicationUser a = _context.ApplicationUser
                                                        .Include(a => a.ServiceLst)
                                                        .FirstOrDefault(a => a.Id == userId);
            //Service service = _serviceRepository.FirstOrDefault(s => s.ApplicationUser.Id == userId, includeProperties: "ApplicationUser");
            List<OrderDetails> odLst = new List<OrderDetails>();
            foreach (var service in a.ServiceLst)
            {
                List<OrderDetails> lstOrderDetailsLocal = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => od.ServiceId == service.ID, includeProperties: "Order,Quotation,Service");
                foreach (var orderDetail in lstOrderDetailsLocal)
                {
                    odLst.Add(orderDetail);
                }
            }
            ////List<OrderDetails> lstOrderDetails = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => od.ServiceId == service.ID, includeProperties: "Order,Quotation,Servicio");
            //List<OrderDetails> lstOrderDetailsWithServiceApplicationUserEqualsToUserId = new List<OrderDetails>();
            //foreach (var orderDetailsLocal in lstOrderDetails)
            //{
            //    if(orderDetailsLocal.Service.ApplicationUser.Id == userId)
            //    {
            //        lstOrderDetailsWithServiceApplicationUserEqualsToUserId.Add(orderDetailsLocal);
            //    }
            //}
            return odLst;
        }

        public Service GetServiceIncludeApplicationUserFirstOrDefault(Guid serviceId)
        {
            return _serviceRepository.FirstOrDefault(s => s.ID == serviceId, includeProperties: "ApplicationUser");
        }

        public Service GetServiceIncludeApplicationUserServiceTypeFirstOrDefault(Guid serviceId)
        {
            return _serviceRepository.FirstOrDefault(s => s.ID == serviceId, includeProperties: "ApplicationUser,serviceType");
        }

        public Order GetOrderIncludeOrderDetailsServiceApplicationUserFirstOrDefault(Guid orderId)
        {
            Order orderLocal = _orderRepository.FirstOrDefault(o => o.Id == orderId, includeProperties: "LstOrderDetails");
            foreach (var orderDetails in orderLocal.LstOrderDetails)
            {
                orderDetails.Service = _serviceRepository.FirstOrDefault(s => s.ID == orderDetails.ServiceId, includeProperties: "ApplicationUser");
            }
            return orderLocal;
        }

        public List<OrderDetails> GetListOrderDetailsIncludeOrderServiceServiceTypeWhereServiceIdEqualsServiceID(Guid serviceId)
        {
            //List<OrderDetails> lstOrderDetails = (List<OrderDetails>)_orderDetailsRepository.GetAll(s => s.ServiceId == serviceId, includeProperties: "Order,Service");
            //foreach (var orderDetails in lstOrderDetails)
            //{
            //    orderDetails.Service.serviceType = _serviceTypeRepository.FirstOrDefault(s => s.Id == orderDetails.Service.ServiceTypeId, includeProperties: "serviceType");
            //}
            return _context.OrderDetails.Include(od => od.Order)
                                        .Include(od => od.Service)
                                          .ThenInclude(s => s.serviceType)
                                        .Where(od => od.Service.ID == serviceId)
                                        .ToList();
            
        }

        public TaskModel GetTaskIncludeQuotationOrderDetailsFirstOrDefault(Guid taskId)
        {

            return _context.Task
                                .Include(t => t.QuotationModel)
                                    .ThenInclude(q => q.OrderDetails)
                                    .FirstOrDefault(t => t.Id == taskId);
        }

        public TaskModel GetTaskModelIncludeLstMaterialQuotationOrderDetailsOrderFirstOrDefaultTaskIdEqualsTaskId(Guid taskId)
        {
            return _context.Task
                                .Include(t => t.ListMaterial)
                                .Include(t => t.QuotationModel)
                                    .ThenInclude(q => q.OrderDetails)
                                        .ThenInclude(od => od.Order)
                                        .FirstOrDefault(t => t.Id == taskId);
        }

        public Material GetMaterialIncludeTaskFirstOrDefaultIdEqualsMaterialsId(Guid materialId)
        {
            Material material = _materialRepository.FirstOrDefault(m => m.Id == materialId, includeProperties: "Task");
            return material;
        }

        public List<Order> GetAllLstOrderIncludeLstOrderDetailsServiceServiceTypeToList()
        {
            //List<Order> lstOrder = (List<Order>)_orderRepository.GetAll(includeProperties: "LstOrderDetails");
            //foreach (var order in lstOrder)
            //{
            //    foreach (var orderDetails in order.LstOrderDetails)
            //    {
            //        orderDetails.Service = _serviceRepository.FirstOrDefault(s => s.ID == orderDetails.ServiceId, includeProperties:"serviceType");
            //    }
            //}
            //return lstOrder;
            var orderLstLocal = _context.Order
                                        .ToList();
            foreach (var order in orderLstLocal)
            {
                order.LstOrderDetails = _context.OrderDetails
                                                            .Include(od => od.Service)
                                                                .ThenInclude(s => s.serviceType)
                                                            .Where(od => od.OrderId == order.Id)
                                                            .ToList();
            }
            return orderLstLocal;           
        }

        public List<OrderDetails> GetLstOrderDetailsIncludeOrderServiceServiceTypeWhereOrderIdEqualsOrderId(Guid orderId)
        {
            List<OrderDetails> lstOrderDetails = (List<OrderDetails>)_orderDetailsRepository.GetAll(od => od.OrderId == orderId, includeProperties: "Service");
            foreach (var orderDetails in lstOrderDetails)
            {
                orderDetails.Service.serviceType = _serviceTypeRepository.FirstOrDefault(st => st.Id == orderDetails.Service.ServiceTypeId);
            }
            return lstOrderDetails;
        }

        public List<Quotation> GetLstQuotationIncludeOrderDetailsOrderTaskListMaterialWhereOrderIdEqualsOrderId(Guid orderId)
        {
            List<Quotation> lstQuotation = (List<Quotation>)_quotationRepository.GetAll(q => q.OrderDetails.OrderId == orderId, includeProperties: "OrderDetails,Tasks");
            foreach (var quotation in lstQuotation)
            {
                quotation.OrderDetails.Order = _orderRepository.FirstOrDefault(o => o.Id == orderId);
                quotation.Tasks = (List<TaskModel>)_taskRepository.GetAll(t => t.QuotationId == quotation.Id, includeProperties: "ListMaterial");
            }
            return lstQuotation;
        }

        public List<Guid> GetLstServiceFromTheSameServiceTypeFromOrderServiceType(Guid serviceTypeId)
        {
            return _context.ServiceModel
                                                                    .Include(c => c.serviceType)
                                                                    .Where(c => c.ServiceTypeId == serviceTypeId)
                                                                    .Select(c => c.ID)
                                                                    .ToList();
        }

        public OrderDetails GetOrderDetailsIncludeOrderServiceApplicationUserFirstOrDefaultOrderDetailsIdEqualsOrderDetailsId(Guid orderDetailsId)
        {
            OrderDetails orderDetails = _orderDetailsRepository.FirstOrDefault(od => od.Id == orderDetailsId, includeProperties: "Order,Service");
            orderDetails.Service.ApplicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == orderDetails.Service.UserId);
            return orderDetails;
        }

        public List<OrderDetails> GetLstOrderDetailsIncludeOrderServiceApplicationUserWhereOrderIdAndApplicationUserId(Guid orderId, string userId)
        {
            return _context.OrderDetails
                                                                  .Include(od => od.Order)
                                                                  .Include(od => od.Service)
                                                                       .ThenInclude(s => s.ApplicationUser)
                                                                  .Where(orderDtls => orderDtls.Order.Id == orderId && orderDtls.Service.UserId == userId)
                                                                  .ToList();
        }

        public List<Guid> GetLstServiceFromSameUserWhereUserIdEqualsUserIdSelectId(string userId)
        {
            return _context.ServiceModel
                                                                    .Include(c => c.ApplicationUser)
                                                                    .Where(c => c.UserId == userId)
                                                                    .Select(c => c.ID)
                                                                    .ToList();
        }

        public ApplicationUser GetApplicationUserIncludeServiceLst(string userId)
        {
            ApplicationUser applicationUser = _applicationUserRepository.FirstOrDefault(a => a.Id == userId, includeProperties: "ServiceLst");
            return applicationUser;
        }

        public List<EmployeeUser> GetLstEmployeesIncludeServiceList()
        {
            List<EmployeeUser> lstEmployee = (List<EmployeeUser>)_employeeRepository.GetAll(includeProperties: "ServiceLst");
            return lstEmployee;
        }

        public EmployeeUser GetEmployeeIncludeLstEmployedByFirstOrDefaultEmployeeIdEqualsEmployeeId(string employeeId)
        {
            return _employeeRepository.FirstOrDefault(e => e.Id == employeeId, includeProperties: "EmployedBy");
        }

        public Service GetServiceFirstOrDefault(Guid serviceId)
        {
            return _serviceRepository.FirstOrDefault(s => s.ID == serviceId);
        }

        public Quotation GetQuotationIncludeOrderTaskListMaterialWhereOrderIdEqualsOrderId(Guid orderId)
        {
            return _context.Quotation
                                                 .Include(q => q.OrderDetails)
                                                    .ThenInclude(q => q.Order)
                                                 .Include(q => q.Tasks)
                                                    .ThenInclude(t => t.ListMaterial)
                                                 .FirstOrDefault(q => q.OrderDetails.Order.Id == orderId);
        }

        public Quotation GetQuotationIncludeOrderDetailsOrderTaskPicturesFirstOrDefaultWhereOrderIdEquals(Guid orderId)
        {
            
                var quotation = _context.Quotation
                                                .Include(q => q.OrderDetails)
                                                    .ThenInclude(q => q.Order)
                                                 .Include(q => q.Tasks)
                                                    .ThenInclude(t => t.Pictures)
                                                 .FirstOrDefault(q => q.OrderDetails.Order.Id == orderId);
            return quotation;
        }

        public TaskModel GetTaskIncludePicturesFirstOrDefaultWhereTaskIdEquals(Guid taskId)
        {
            return _taskRepository.FirstOrDefault(t => t.Id == taskId, includeProperties: "Pictures");
        }

        public Picture GetPictureFirstOrDefaultWherePictureIdEquals(Guid pictureId)
        {
            return _pictureRepository.FirstOrDefault(p => p.PictureId == pictureId);
        }

        public Quotation GetQuoationIncludeOrderDetailsServiceApplicationUserFirstOrDefaultWhereQuotationIdEquals(Guid quotationId)
        {
            Quotation quotation = _quotationRepository.FirstOrDefault(q => q.Id == quotationId, includeProperties: "OrderDetails");
            quotation.OrderDetails.Service = _serviceRepository.FirstOrDefault(s => s.ID == quotation.OrderDetails.ServiceId, includeProperties: "ApplicationUser");
            return quotation;
        }

        public TaskModel GetTaskIncludeQuotationOrderDetailsOrderFirstOrDefaultWhereOrderDetailsIdEquals(Guid orderDetailsId)
        {
            var quotation = _context.Quotation
                                              .Include(q => q.Tasks)
                                              .FirstOrDefault(q => q.OrderDetailsId == orderDetailsId);
            var task = new TaskModel();
                if (quotation.Tasks.Count>0)
            {
                task = quotation.Tasks[0];
            }
                //_context.Task
                //                                .Include(t => t.QuotationModel)
                //                                        .ThenInclude(q => q.OrderDetails)
                //                                            .ThenInclude(od => od.Order)
                //                                      .FirstOrDefault(od => od.QuotationModel.OrderDetails.Id == orderDetailsId);
            return task;
        }

        public Quotation GetQuotationIncludeTaskOrderDetailsFirstOrDefaultWhereOrderDetailsEquals(Guid orderDetailsId)
        {
            return _context.Quotation
                                            .Include(q => q.Tasks)
                                                .Include(q => q.OrderDetails)
                                            .FirstOrDefault(q => q.OrderDetails.Id == orderDetailsId);
        }

        public TaskModel GetTaskIncludeQuotationOrderDetailsOrderFirstOrDefaultWhereTaskIdEquals(Guid taskId)
        {
            return _context.Task
                                           .Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetails)
                                                    .ThenInclude(q => q.Order)
                                           .FirstOrDefault(m => m.Id == taskId);
        }

        public TaskModel GetTaskIncludeLstMaterialPicturesQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals(Guid taskId)
        {
            var task = _context.Task
                                    .Include(t => t.Pictures)
                                    .Include(t => t.ListMaterial)
                                    .Include(t => t.QuotationModel)
                                        .ThenInclude(q => q.OrderDetails)
                                            .ThenInclude(od => od.Order)
                                    .FirstOrDefault(t => t.Id == taskId);
            return task;
        }

        public TaskModel GetTaskFirstOrDefaultWhereTaskIdEquals(Guid id)
        {
            return _context.Task.FirstOrDefault(t => t.Id == id);
        }

        public TaskModel GetTaskIncludeQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals(Guid taskId)
        {
            return _context.Task
                                            .Include(t => t.QuotationModel)
                                                .ThenInclude(q => q.OrderDetails)
                                                    .ThenInclude(od => od.Order)
                                            .FirstOrDefault(m => m.Id == taskId);
        }

        public IList<TaskModel> GetAllTaskLstIncludeQuotationOrderDetailsOrder()
        {
            return _context.Task
                                          .Include(t => t.QuotationModel)
                                            .ThenInclude(q => q.OrderDetails)
                                                .ThenInclude(od => od.Order)
                                          .ToList(); 
        }

        public ApplicationUser GetAppicationUserFirstOrDefault(string userId)
        {
            return _context.ApplicationUser.FirstOrDefault(a => a.Id == userId);

        }

        public List<Service> GetServiceLstIncludeApplicationUserWhereUserIdEquals(string userId)
        {
                  return                       _context.ServiceModel
                                                              .Include(s => s.ApplicationUser)
                                                              .Where(s => s.ApplicationUser.Id == userId)
                                                              .ToList();
        }

        public List<OrderDetails> GetAllOrderDetailsIncludeOrderServiceApplicationUserWhereServiceIdEquals(Guid serviceId)
        {
            List<OrderDetails> orderDetailsLst = _context.OrderDetails
                                                            .Include(od => od.Order)
                                                            .Include(od => od.Service)
                                                                .ThenInclude(s => s.ApplicationUser)
                                                            .Where(od => od.Service.ID == serviceId).ToList();
            return orderDetailsLst;
        }

        public Quotation GetQuotationIncludeOrderDetailsTaskListMaterialPicturesFirstOrDefaultWhereOrderDetailsIdEquals(Guid orderDetailsId)
        {
            return _context.Quotation
                                                                .Include(q => q.OrderDetails)
                                                                .Include(q => q.Tasks)
                                                                    .ThenInclude(t => t.ListMaterial)
                                                                .FirstOrDefault(q => q.OrderDetails.Id == orderDetailsId);
        }

        public Order GetOrderFirstOrDefaultWhereOrderIdEquals(Guid orderId)
        {
            return _context.Order.FirstOrDefault(o => o.Id == orderId);
        }

        public List<OrderDetails> GetOrderDetailsIncludeOrderWhereOrderIdEquals(Guid orderId)
        {
            return _context.OrderDetails
                                                                            .Include(o => o.Order)
                                                                            .Where(o => o.Order.Id == orderId).ToList();
        }

        public List<ApplicationUser> GetAllApplicationUser()
        {
            return _context.ApplicationUser.ToList();
        }

        public List<EmployeeUser> GetAllEmployeesIncludeServiceLstEmployedByWhereEmployedByIdEquals(string EmployerId)
        {
            return _context.Employee
                                                              .Include(e => e.ServiceLst)
                                                              .Include(e => e.EmployedBy)
                                                              .Where(e => e.EmployedBy.Id == EmployerId)
                                                              .ToList();
        }

        public List<OrderDetails> GetAllOrderDetailsIncludeOrderServiceQuotationWhereEmployeeIdEquals(string employeeId)
        {
            return _context.OrderDetails
                                        .Include(od => od.Order)
                                        .Include(od => od.Service)
                                        .Include(od => od.Quotation)
                                            .ThenInclude(q => q.Employee)
                                            .Where(od => od.Quotation.Employee.Id == employeeId)
                                            .ToList();
        }

        public List<EmployeeUser> GetAllEmployeesWhereEmployedByIdEquals(string employerId)
        {
            return _context.Employee.Include(e => e.EmployedBy).Where(e => e.EmployedBy.Id == employerId).ToList();
        }

        public OrderDetails GetOrderDetailsIncludeOrderFirstOrDefaultWhereOrderDetailsIdEquals(Guid orderDetailsId)
        {
            return _context.OrderDetails.Include(od => od.Order).FirstOrDefault(od => od.Id == orderDetailsId);
        }

        public List<OrderDetails> GetAllOrderDetailsIncludeOrderQuotationServiceServiceTypeApplicationUserWhereUserIdEquialsUserId(string provideerId)
        {
       
            List<OrderDetails> orderDetailsLst =  _context.OrderDetails.Include(od => od.Order)
                                        .Include(od => od.Service)
                                            .ThenInclude(s => s.ApplicationUser)
                                        .Where(od => od.Service.ApplicationUser.Id == provideerId)
                                        .ToList();
            foreach (var orderDetail in orderDetailsLst)
            {
                orderDetail.Service.serviceType = _context.ServiceType.FirstOrDefault(st => st.Id == orderDetail.Service.ServiceTypeId);
            }
            return orderDetailsLst;
        }

        public List<PredefinedTask> GetAllPredefinedTaskWhereServiceIdEquals(string serviceId)
        {
            Guid id = Guid.Parse(serviceId);
            return _context.PredefinedTask.Where(pt => pt.ServiceId == id).ToList();
        }
    }
}
