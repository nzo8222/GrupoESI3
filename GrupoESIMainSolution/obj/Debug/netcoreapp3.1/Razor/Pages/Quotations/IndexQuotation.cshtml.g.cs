#pragma checksum "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8faf575cfc9766ab4bfc60e3703f3be4f95f2a92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GrupoESI.Pages.Quotations.Pages_Quotations_IndexQuotation), @"mvc.1.0.razor-page", @"/Pages/Quotations/IndexQuotation.cshtml")]
namespace GrupoESI.Pages.Quotations
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8faf575cfc9766ab4bfc60e3703f3be4f95f2a92", @"/Pages/Quotations/IndexQuotation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a3bcd6ad8b5d74805dbb02da84de0a9b9c8af3f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Quotations_IndexQuotation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "IndexQuotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./CreateQuotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./DeleteQuotation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container backgroundWhite"">
    <h2 class=""text-info"">Indice de cotizaciones</h2>
    <div class=""card"">
        <div class=""card-header bg-dark text-light ml-0 row container"">
            <div class=""col-6"">
                <i class=""fa fa-user-o""></i>
            </div>
        </div>
        <div class=""card-body container"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8faf575cfc9766ab4bfc60e3703f3be4f95f2a925765", async() => {
                WriteLiteral("\r\n                <br />\r\n                <label id=\"_provideerId\" hidden>");
#nullable restore
#line 18 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                                           Write(Model._indexQuotationVM.ProvideerId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</label>
                <div class=""border backgroundWhite"">
                    <div style=""height:60px;"" class=""container border border-secondary"">
                        <div class=""row"">
                            <div class=""col-11"">
                                <div class=""row"" style=""padding-top:10px"">
                                    <div class=""col-4"">
                                        ");
#nullable restore
#line 25 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                                   Write(Html.Editor("searchConcepto", new { htmlAttributes = new { @class = "form-control", placeholder = "Concepto..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"col-4\">\r\n                                        ");
#nullable restore
#line 28 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                                   Write(Html.Editor("searchNombre", new { htmlAttributes = new { @class = "form-control", placeholder = "Nombre del servicio..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"col-4\">\r\n                                        ");
#nullable restore
#line 31 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                                   Write(Html.Editor("searchDescripcion", new { htmlAttributes = new { @class = "form-control", placeholder = "Descripcion de la cotizacion..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                            <div class=""col-1"">
                                <div class=""row"" style=""padding-top:10px; padding-right:15px;"">
                                    <button type=""submit"" name=""submit"" value=""Search"" class=""btn btn-info form-control"">
                                        <i class=""fas fa-search""></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""table-responsive"">
                <table class=""table table-striped"">
                    <thead>
                        <tr class=""table-secondary"">
                            <th scope=""col"">
                                ");
#nullable restore
#line 51 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                           Write(Html.DisplayNameFor(model => model._indexQuotationVM.OrderDetails[0].Order.Concepto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th scope=\"col\">\r\n                                ");
#nullable restore
#line 54 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                           Write(Html.DisplayNameFor(model => model._indexQuotationVM.OrderDetails[0].Service.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th scope=\"col\">\r\n                                ");
#nullable restore
#line 57 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                           Write(Html.DisplayNameFor(model => model._indexQuotationVM.OrderDetails[0].Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th scope=\"col\">\r\n");
            WriteLiteral("                            </th>\r\n                            <th scope=\"col\">\r\n                                ");
#nullable restore
#line 63 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                           Write(Html.DisplayNameFor(model => model._indexQuotationVM.OrderDetails[0].Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n                            <th scope=\"col\">\r\n\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 71 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                         foreach (var item in Model._indexQuotationVM.OrderDetails)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 76 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Order.Concepto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 79 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Service.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 82 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
            WriteLiteral("                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 88 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8faf575cfc9766ab4bfc60e3703f3be4f95f2a9214526", async() => {
                WriteLiteral("Ver cotizacion");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-orderDetailsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                                                                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderDetailsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-orderDetailsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderDetailsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8faf575cfc9766ab4bfc60e3703f3be4f95f2a9216914", async() => {
                WriteLiteral("Borrar cotizacion");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-orderDetailsId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderDetailsId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-orderDetailsId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["orderDetailsId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 96 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td colspan=\"5\" class=\"text-right\">\r\n                                <div");
            BeginWriteAttribute("page-model", " page-model=\"", 5264, "\"", 5312, 1);
#nullable restore
#line 99 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
WriteAttributeValue("", 5277, Model._indexQuotationVM.pagingInfo, 5277, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" asp-action=""IndexQuotation"" page-class=""btn border""
                                     page-class-normal=""btn btn-light"" page-class-selected=""btn btn-info active"" class=""btn-group"">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </div>
    </div>
</div>
<div class=""table-responsive"">
    <table id=""tblData"" class=""display"">
        <thead>
            <tr>
                <th>

                    Fecha
                </th>
                <th>
                    Dirección
                </th>
                <th>
                    Servicio
                </th>
                <th>
                    Tipo de servicio
                </th>
                <th>
                    Estado del pedido
                </th>
                <th>
                    Concepto
                </th>
                <th>

                <");
            WriteLiteral("/th>\r\n\r\n            </tr>\r\n        </thead>\r\n    </table>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 145 "C:\GrupoESI\GrupoESIMainSolution\Pages\Quotations\IndexQuotation.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js""></script>
    <script>
        $(document).ready(function () {
            provideerId = document.getElementById('_provideerId');
            console.log(provideerId.innerText);

            loadDataTable(provideerId.innerText);
        });
        function loadDataTable(provideerId) {
            $(""#tblData"").DataTable(
                {
                    ""ajax"":
                    {
                        ""type"": ""GET"",
                        ""url"": ""/api/Provideer/GetProvideerOrderList?provideerId="" + provideerId
                    },
                    ""columns"": [
                        { ""data"": ""date"", ""width"": ""10%"" },
                        { ""data"": ""address"", ""width"": ""10%"" },
                        { ""data"": ""serviceName"", ""width"": ""10%"" },
                        { ""data"": ""serviceType"", ""width"": ""10%"" },
                        { ""data"": ""orderStatus"", ""width"": ""10%"" },
           ");
                WriteLiteral(@"             { ""data"": ""concept"", ""width"": ""10%"" },
                        {
                            ""data"": ""orderDetailsId"",
                            ""render"": function (data) {
                                return `
                                    <div class=""text-center"">
                                        <a href=""/Quotations/CreateQuotation?orderDetailsId=${data}"" class=""btn btn-success text-white"" style=""cursor:pointer"">
                                           Ver Cotizacione
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
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GrupoESI.IndexQuotationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESI.IndexQuotationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GrupoESI.IndexQuotationModel>)PageContext?.ViewData;
        public GrupoESI.IndexQuotationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
