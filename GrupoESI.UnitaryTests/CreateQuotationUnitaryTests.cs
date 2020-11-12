
using GrupoESIDataAccess.Queries;
using GrupoESIModels.Models;
using GrupoESI;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System;
using System.Collections.Generic;

using Xunit;

namespace GrupoESI.UnitTestsXUnit
{
    public class CreateQuotationUnitTests : IDisposable
    {
        private CreateQuotationModel pageModel { get; set; }
        private Guid LocalGuid { get; set; }
        private Quotation quotationLocal { get; set; }
        private OrderDetails od { get; set; }
        private List<OrderDetails> lstOrderDetails { get; set; }
        private List<EmployeeUser> lstEmployees { get; set; }
        public CreateQuotationUnitTests()
        {
            var guid = "88e5ef7f-1a18-44f1-aefd-910e07aed28a";
            LocalGuid = new Guid(guid);
            var iqueriesInterface = new Mock<IQueries>();
            EmployeeUser employee = new EmployeeUser
            {
                Id = "123",
                Email = "newEmail@gmail.com",
                EmployedBy = new ApplicationUser(),
                Name = "employee",
                ServiceLst = new List<Service>(),
                UserName = "employee",
                PhoneNumber = "123"
            };
            quotationLocal = new Quotation
            {
                Description = "a",
                QuotationSaveDate = new DateTime(),
                ProviderArrivalDate = new DateTime(),
                Id = new Guid(),
                OrderDetails = new OrderDetails(),
                Tasks = new System.Collections.Generic.List<TaskModel>(),
                Employee = employee
            };
            od = new OrderDetails
            {
                Id = LocalGuid,
                Cost = 0,
                Order = new Order(),
                
                Service = new Service(),
                Status = ""
            };
            
            lstEmployees = new List<EmployeeUser>();
            lstEmployees.Add(employee);
            lstOrderDetails = new List<OrderDetails>();
            lstOrderDetails.Add(od);
            iqueriesInterface.Setup
                (q => q.GetEmployeesAssosiatedToThisQuotation())
                .Returns(lstEmployees);
            iqueriesInterface.Setup
                (q => q.GetOrderDetailsWithOrderServiceApplicationUser(LocalGuid))
                .Returns(od);
            iqueriesInterface.Setup
                (q => q.GetOrderDetailsWithOrderServiceApplicationUser(LocalGuid))
                .Returns(od);
            iqueriesInterface.Setup
                (q => q.GetQuotationIncludeOrderDetailsOrdersEmployeeTasksListMaterialPicturesFirstOrDefault(LocalGuid))
                .Returns(quotationLocal);
            iqueriesInterface.Setup
                (q => q.GetListOrderDetailsWithOrderServiceApplicationUserFromSameUser(od))
                .Returns(lstOrderDetails);

            var emailSender = new Mock<IEmailSender>();
            pageModel = new CreateQuotationModel(emailSender.Object, iqueriesInterface.Object);
        }
        public void Dispose()
        {

        }

        [Fact]
        public void OnGetCreateQuotation_IdIsNull_ShouldReturnNotFound()
        {
            Guid guid = Guid.Empty;
            var result = pageModel.OnGet(guid);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void OnGetCreateQuotation_IdNotNull_ShouldReturnPage()
        {
            //Guid guid = Guid.NewGuid();
            var result = pageModel.OnGet(LocalGuid);
            Assert.Equal(pageModel._QuotationTaskMaterialVM.QuotationModel, quotationLocal);
            Assert.Equal(pageModel._QuotationTaskMaterialVM.lstOrderDetailsSameUserServices, lstOrderDetails);
            Assert.Equal(pageModel._QuotationTaskMaterialVM.lstEmployees, lstEmployees);
            Assert.IsType<PageResult>(result);
        }

    }
}
