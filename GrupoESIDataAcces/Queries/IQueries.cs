
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoESIDataAccess.Queries
{
    public interface IQueries
    {
        Task SaveChangesAsync();
        void SaveChanges();
        TaskModel GetTaskIncludeQuotationOrderDetailsOrderFirstOrDefaultWhereOrderDetailsIdEquals(Guid orderDetailsId);
        Quotation GetQuoationIncludeOrderDetailsServiceApplicationUserFirstOrDefaultWhereQuotationIdEquals(Guid quotationId);
        Picture GetPictureFirstOrDefaultWherePictureIdEquals(Guid pictureId);
        TaskModel GetTaskIncludePicturesFirstOrDefaultWhereTaskIdEquals(Guid taskId);
        Quotation GetQuotationIncludeOrderDetailsOrderTaskPicturesFirstOrDefaultWhereOrderIdEquals(Guid orderId);
        OrderDetails GetOrderDetailsIncludeOrderFirstOrDefaultWhereOrderDetailsIdEquals(Guid orderDetailsId);
        ApplicationUser GetAppicationUserFirstOrDefault(string userId);
        TaskModel GetTaskIncludeQuotationOrderDetailsOrderFirstOrDefaultWhereTaskIdEquals(Guid taskId);
        IList<TaskModel> GetAllTaskLstIncludeQuotationOrderDetailsOrder();
        List<ApplicationUser> GetAllApplicationUser();
        TaskModel GetTaskIncludeQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals(Guid taskId);
        Quotation GetQuotationIncludeOrderTaskListMaterialWhereOrderIdEqualsOrderId(Guid orderId);
        List<OrderDetails> GetAllOrderDetailsIncludeOrderServiceQuotationWhereEmployeeIdEquals(string employeeId);
        Service GetServiceFirstOrDefault(Guid serviceId);
        EmployeeUser GetEmployeeIncludeLstEmployedByFirstOrDefaultEmployeeIdEqualsEmployeeId(string employeeId);
        List<EmployeeUser> GetAllEmployeesIncludeServiceLstEmployedByWhereEmployedByIdEquals(string EmployerId);
        Quotation GetQuotationIncludeTaskOrderDetailsFirstOrDefaultWhereOrderDetailsEquals(Guid orderDetailsId);
        List<EmployeeUser> GetAllEmployeesWhereEmployedByIdEquals(string employerId);
        List<EmployeeUser> GetLstEmployeesIncludeServiceList();
        List<Service> GetServiceLstIncludeApplicationUserWhereUserIdEquals(string id);
        ApplicationUser GetApplicationUserIncludeServiceLst(string userId);
        List<Guid> GetLstServiceFromSameUserWhereUserIdEqualsUserIdSelectId(string userId);
        TaskModel GetTaskIncludeLstMaterialPicturesQuotationModelOrderDetailsModelOrderFirstOrDefaultWhereTaskIdEquals(Guid taskId);
        List<OrderDetails> GetAllOrderDetailsIncludeOrderServiceApplicationUserWhereServiceIdEquals(Guid serviceId);
        TaskModel GetTaskFirstOrDefaultWhereTaskIdEquals(Guid id);
        List<OrderDetails> GetLstOrderDetailsIncludeOrderServiceApplicationUserWhereOrderIdAndApplicationUserId(Guid orderId, string userId);
        Quotation GetQuotationIncludeOrderDetailsTaskListMaterialPicturesFirstOrDefaultWhereOrderDetailsIdEquals(Guid orderDetailsId);
        OrderDetails GetOrderDetailsIncludeOrderServiceApplicationUserFirstOrDefaultOrderDetailsIdEqualsOrderDetailsId(Guid orderDetailsId);
        List<Guid> GetLstServiceFromTheSameServiceTypeFromOrderServiceType(Guid serviceTypeId);
        List<Quotation> GetLstQuotationIncludeOrderDetailsOrderTaskListMaterialWhereOrderIdEqualsOrderId(Guid orderId);
        List<OrderDetails> GetLstOrderDetailsIncludeOrderServiceServiceTypeWhereOrderIdEqualsOrderId(Guid orderId);
        List<Order> GetAllLstOrderIncludeLstOrderDetailsServiceServiceTypeToList();
        Material GetMaterialIncludeTaskFirstOrDefaultIdEqualsMaterialsId(Guid materialId);
        TaskModel GetTaskModelIncludeLstMaterialQuotationOrderDetailsOrderFirstOrDefaultTaskIdEqualsTaskId(Guid taskId);
        TaskModel GetTaskIncludeQuotationOrderDetailsFirstOrDefault(Guid taskId);
        List<OrderDetails> GetListOrderDetailsIncludeOrderServiceServiceTypeWhereServiceIdEqualsServiceID(Guid serviceId);
        Order GetOrderIncludeOrderDetailsServiceApplicationUserFirstOrDefault(Guid orderId);
        Order GetOrderFirstOrDefaultWhereOrderIdEquals(Guid orderId);
        Service GetServiceIncludeApplicationUserServiceTypeFirstOrDefault(Guid serviceId);
        List<OrderDetails> GetOrderDetailsIncludeOrderWhereOrderIdEquals(Guid orderId);
        Service GetServiceIncludeApplicationUserFirstOrDefault(Guid serviceId);
        List<OrderDetails> GetOrderDetailsIncludeOrderQuotationServiceThenIncludeApplicationUserWhereUserIdEquialsUserId(string userId);
        List<OrderDetails> GetOrderDetailsFromSameOrder(Guid orderId);
        Order GetOrderByOrderId(Guid orderId);
        Quotation GetQuotationByQuotationId(Guid quotationId);
        Quotation GetQuotationWithOrderDetailsServiceApplicationUserWhereQuotationIdEqualsId(Guid QuotationId);
        Quotation GetQuotationIncludeOrderDetailsOrdersEmployeeTasksListMaterialPicturesFirstOrDefault(Guid orderDetailsId);
        OrderDetails GetOrderDetailsWithOrderServiceApplicationUser(Guid orderDetailsId);
        System.Collections.Generic.List<OrderDetails> GetListOrderDetailsWithOrderServiceApplicationUserFromSameUser(OrderDetails userId);
        List<EmployeeUser> GetEmployeesAssosiatedToThisQuotation();
    }
}