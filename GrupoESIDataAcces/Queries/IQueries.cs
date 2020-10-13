
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

        Service GetServiceIncludeApplicationUserServiceTypeFirstOrDefault(Guid serviceId);
        Service GetServiceIncludeApplicationUserFirstOrDefault(Guid serviceId);
        List<OrderDetails> GetOrderDetailsIncludeOrderQuotationServiceThenIncludeApplicationUserWhereUserIdEquialsUserId(string userId);
        List<OrderDetails> GetOrderDetailsFromSameOrder(Guid orderId);
        Order GetOrderByOrderId(Guid orderId);
        Quotation GetQuotationByQuotationId(Guid quotationId);
        Quotation GetQuotationWithOrderDetailsServiceApplicationUserWhereQuotationIdEqualsId(Guid QuotationId);
        Quotation GetQuotationWithOrderDetailsOrdersTasksListMaterialFirstOrDefault(Guid orderDetailsId);
        OrderDetails GetOrderDetailsWithOrderServiceApplicationUser(Guid orderDetailsId);
        System.Collections.Generic.List<OrderDetails> GetListOrderDetailsWithOrderServiceApplicationUserFromSameUser(OrderDetails userId);
        List<EmployeeUser> GetEmployeesAssosiatedToThisQuotation();
    }
}