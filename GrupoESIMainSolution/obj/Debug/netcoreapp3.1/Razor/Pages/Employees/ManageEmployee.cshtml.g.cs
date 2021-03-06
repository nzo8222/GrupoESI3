#pragma checksum "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "492c8da0a16420d91c85491e342be4fcff5f6a16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GrupoESI.Pages.Employees.Pages_Employees_ManageEmployee), @"mvc.1.0.razor-page", @"/Pages/Employees/ManageEmployee.cshtml")]
namespace GrupoESI.Pages.Employees
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\GrupoESI\GrupoESIMainSolution\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"492c8da0a16420d91c85491e342be4fcff5f6a16", @"/Pages/Employees/ManageEmployee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a3bcd6ad8b5d74805dbb02da84de0a9b9c8af3f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Employees_ManageEmployee : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
  
    ViewData["Title"] = "ManageEmployee";

#line default
#line hidden
#nullable disable
            WriteLiteral("<label id=\"_EmployerId\" hidden>");
#nullable restore
#line 6 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                          Write(Model._ManageEmployeesVM.EmployerId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
<h2 class=""text-info"">Manejar empleados</h2>
<div class=""container backgroundWhite"">
    <div class=""card"">
        <div class=""card-header bg-dark text-light ml-0 row container"">
            <div class=""card-header bg-dark text-light ml-0 row container"">
                <div class=""col-6"">
                    <i class=""fa fa-user-o""></i>
                </div>
            </div>
        </div>

        <div class=""card-body container"">
            <div class=""row"">
                <div class=""col"">
                    <div class=""table-responsive"">
                        <div>
                            <table id=""tblData"" class=""display"">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Email</th>
                                    </tr>
                                </thead>
                            </table>
                        </div");
            WriteLiteral(">\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    
    <script src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js""></script>
    <script>
        $(document).ready(function () {
            employerId = document.getElementById('_EmployerId');
            console.log(employerId.innerText);
            
            loadDataTable(employerId.innerText);
        });
        function loadDataTable(employerId) {
            $(""#tblData"").DataTable(
                {
                    ""ajax"":
                    {
                        ""type"": ""GET"",
                        ""url"": ""/api/Employee/GetInquiryList?employerId="" + employerId
                    },
                    ""columns"": [

                        { ""data"": ""name"", ""width"": ""10%"" },
                        { ""data"": ""email"", ""width"": ""10%"" },
                        
                    ]
                })
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GrupoESI.Pages.Employees.ManageEmployeeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESI.Pages.Employees.ManageEmployeeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESI.Pages.Employees.ManageEmployeeModel>)PageContext?.ViewData;
        public GrupoESI.Pages.Employees.ManageEmployeeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
