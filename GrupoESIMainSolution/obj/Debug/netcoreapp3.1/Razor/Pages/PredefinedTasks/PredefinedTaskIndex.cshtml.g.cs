#pragma checksum "C:\GrupoESI\GrupoESIMainSolution\Pages\PredefinedTasks\PredefinedTaskIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5beeee968f09d7484206ccaf591f9ede460ad492"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GrupoESINuevo.Pages.PredefinedTasks.Pages_PredefinedTasks_PredefinedTaskIndex), @"mvc.1.0.razor-page", @"/Pages/PredefinedTasks/PredefinedTaskIndex.cshtml")]
namespace GrupoESINuevo.Pages.PredefinedTasks
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5beeee968f09d7484206ccaf591f9ede460ad492", @"/Pages/PredefinedTasks/PredefinedTaskIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e835d09f13651228af3ebb24bdaae1235c311e0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PredefinedTasks_PredefinedTaskIndex : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("_serviceId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "CreatePredefinedTask", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5beeee968f09d7484206ccaf591f9ede460ad4924316", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 5 "C:\GrupoESI\GrupoESIMainSolution\Pages\PredefinedTasks\PredefinedTaskIndex.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model._serviceId);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5beeee968f09d7484206ccaf591f9ede460ad4926148", async() => {
                WriteLiteral("\r\n    <i class=\"fas fa-plus\"></i> &nbsp; Agregar nueva tarea predefinida\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-serviceId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 6 "C:\GrupoESI\GrupoESIMainSolution\Pages\PredefinedTasks\PredefinedTaskIndex.cshtml"
                                            WriteLiteral(Model._serviceId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["serviceId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-serviceId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["serviceId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<div>
    <table id=""tblData"" class=""display"">
        <thead>
            <tr>
                <th>
                    Descripción
                </th>
                <th>
                    Duracion
                </th>
                <th>
                    Costo mano de obra
                </th>
                <th>
                    Costo
                </th>
            </tr>
        </thead>
    </table>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 31 "C:\GrupoESI\GrupoESIMainSolution\Pages\PredefinedTasks\PredefinedTaskIndex.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js""></script>
    <script>
        $(document).ready(function () {
            serviceId = document.getElementById('_serviceId');
            //console.log(employerId.innerText);employerId.innerTextemployerId + employerId
            console.log(serviceId.innerText);
            loadDataTable(serviceId.innerText);
        });
        function loadDataTable(serviceId) {
            $(""#tblData"").DataTable(
                {
                    ""ajax"":
                    {
                        ""type"": ""GET"",
                        ""url"": ""/api/PredefinedTask/GetPredefinedTaskLst?serviceId="" + serviceId; 
                    },
                    ""columns"": [
                        { ""data"": ""predefinedTaskDescription"", ""width"": ""10%"" },
                        { ""data"": ""predefinedTaskDuration"", ""width"": ""10%"" },
                        { ""data"": ""predefinedTaskCostHandLabor"", ""width"": ""10%"" },
            ");
                WriteLiteral(@"            { ""data"": ""predefinedTaskCost"", ""width"": ""10%"" },
                        {
                            ""data"": ""predefinedTaskId"",
                            ""render"": function (data) {
                                return `
                                    <div class=""text-center"">
                                        <a href=""/ManageOrders/ManageOrdersIndex?orderId=${data}"" class=""btn btn-success text-white"" style=""cursor:pointer"">
                                           Manejar Cotizaciones
                                        </a>
                                    </div>
                                `;
                            }
                        },
                        {
                            ""data"": ""orderId"",
                            ""render"": function (data) {
                                return `
                                    <div class=""text-center"">
                                        <a href=""/Orders/EditOrder?ord");
                WriteLiteral(@"erId=${data}"" class=""btn btn-primary text-white"" style=""cursor:pointer"">
                                          <i class=""fas fa-edit""></i> Editar
                                        </a>
                                    </div>
                                `;
                            }
                        },
                        {
                            ""data"": ""orderId"",
                            ""render"": function (data) {
                                return `
                                    <div class=""text-center"">
                                        <a href=""/Orders/DetailsOrder?orderId=${data}"" class=""btn btn-info text-white"" style=""cursor:pointer"">
                                          <i class=""fas fa-info-circle""></i> Detalles
                                        </a>
                                    </div>
                                `;
                            }
                        },
                         {
      ");
                WriteLiteral(@"                      ""data"": ""orderId"",
                            ""render"": function (data) {
                                return `
                                    <div class=""text-center"">
                                        <a href=""/Orders/DeleteOrder?orderId=${data}"" class=""btn btn-danger text-white"" style=""cursor:pointer"">
                                          <i class=""fas fa-trash""></i> Borrar
                                        </a>
                                    </div>
                                `;
                            }
                        }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GrupoESI.Pages.PredefinedTasks.PredefinedTaskIndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESI.Pages.PredefinedTasks.PredefinedTaskIndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESI.Pages.PredefinedTasks.PredefinedTaskIndexModel>)PageContext?.ViewData;
        public GrupoESI.Pages.PredefinedTasks.PredefinedTaskIndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
