#pragma checksum "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68f8e2598d18759be5f4e21938c2285f0c0d0ecd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GrupoESINuevo.Pages.Employees.Pages_Employees_ManageEmployee), @"mvc.1.0.razor-page", @"/Pages/Employees/ManageEmployee.cshtml")]
namespace GrupoESINuevo.Pages.Employees
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
#nullable restore
#line 2 "C:\GrupoESI\GrupoESIMainSolution\Pages\_ViewImports.cshtml"
using GrupoESINuevo.TagHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68f8e2598d18759be5f4e21938c2285f0c0d0ecd", @"/Pages/Employees/ManageEmployee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e835d09f13651228af3ebb24bdaae1235c311e0", @"/Pages/_ViewImports.cshtml")]
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
                        <table class=""table table-striped border"">
                            <thead>
                                <tr class=""table-secondary"">
                                    <th scope=""col"">
                                        ");
#nullable restore
#line 26 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                   Write(Html.DisplayNameFor(model => model._ManageEmployeesVM.EmployeeUsrLst[0].Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <th scope=\"col\">\r\n                                        ");
#nullable restore
#line 29 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                   Write(Html.DisplayNameFor(model => model._ManageEmployeesVM.EmployeeUsrLst[0].Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </th>
                                    <th scope=""col"">
                                        Servicios
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 37 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                 foreach (var item in Model._ManageEmployeesVM.EmployeeUsrLst)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 41 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 44 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n");
#nullable restore
#line 47 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                             foreach (var item2 in item.ServiceLst)
                                            {
                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                           Write(Html.DisplayFor(modelItem => item2.Name));

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                                                                         
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 53 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div>\r\n    <table id=\"tblData\" class=\"display\">\r\n");
            WriteLiteral("    </table>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 86 "C:\GrupoESI\GrupoESIMainSolution\Pages\Employees\ManageEmployee.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GrupoESINuevo.Pages.Employees.ManageEmployeeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESINuevo.Pages.Employees.ManageEmployeeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESINuevo.Pages.Employees.ManageEmployeeModel>)PageContext?.ViewData;
        public GrupoESINuevo.Pages.Employees.ManageEmployeeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
