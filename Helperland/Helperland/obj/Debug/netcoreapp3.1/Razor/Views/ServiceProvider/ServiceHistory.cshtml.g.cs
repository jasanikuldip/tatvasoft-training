#pragma checksum "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ce123ebde92bbe82752e6419b7e753fee175951"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_ServiceHistory), @"mvc.1.0.view", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ce123ebde92bbe82752e6419b7e753fee175951", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42bc9d6e9e8a14112369f9b64e80a3af6cdab224", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ServiceProvider_ServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ServiceRequest>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/filter.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/calendar2.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/layer-14.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/layer-719.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
  
    ViewData["Title"] = "Service History";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex justify-content-between mb-2"">
    <div class=""color-64-grey fw-bold t-22"">Current Service Requests</div>
    <div class=""dropdown d-md-none"">
        <div type=""button"" data-bs-toggle=""dropdown"" id=""dropdownsorting"" class=""color-64-grey"" aria-expanded=""false"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9ce123ebde92bbe82752e6419b7e753fee1759515998", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>
        <ul class=""dropdown-menu dropdown-menu-end shadow"" aria-labelledby=""dropdownsorting"">
            <li class=""mx-3 my-2"">
                <div class=""form-check"">
                    <input class=""form-check-input"" value=""1"" onclick=""sortingDropdown(0,'asc',1)"" type=""radio"" name=""serviceHistoryRadio"" id=""serviceHistoryIdAsc"">
                    <label class=""form-check-label"" for=""serviceHistoryIdAsc"">
                        Service Id : Ascending
                    </label>
                </div>
            </li>
            <li class=""mx-3 my-2"">
                <div class=""form-check"">
                    <input class=""form-check-input"" value=""2"" onclick=""sortingDropdown(0,'desc',2)"" type=""radio"" name=""serviceHistoryRadio"" id=""serviceHistoryIdDesc"">
                    <label class=""form-check-label"" for=""serviceHistoryIdDesc"">
                        Service Id : Decending
                    </label>
                </div>
            </li>
            <li class=""mx-3 ");
            WriteLiteral(@"my-2"">
                <div class=""form-check"">
                    <input class=""form-check-input"" value=""1"" onclick=""sortingDropdown(1,'asc',1)"" type=""radio"" name=""serviceHistoryRadio"" id=""serviceHistoryDateNew"">
                    <label class=""form-check-label"" for=""serviceHistoryDateNew"">
                        Service date: Latest
                    </label>
                </div>
            </li>
            <li class=""mx-3 my-2"">
                <div class=""form-check"">
                    <input class=""form-check-input"" value=""2"" onclick=""sortingDropdown(1,'desc',2)"" type=""radio"" name=""serviceHistoryRadio"" id=""serviceHistoryDateOld"">
                    <label class=""form-check-label"" for=""serviceHistoryDateOld"">
                        Service date: Oldest
                    </label>
                </div>
            </li>
            <li class=""mx-3 my-2"">
                <div class=""form-check"">
                    <input class=""form-check-input"" value=""3"" onclick=""sortingD");
            WriteLiteral(@"ropdown(2,'asc',3)"" type=""radio"" name=""serviceHistoryRadio"" id=""customerAHistory"">
                    <label class=""form-check-label"" for=""customerAHistory"">
                        Customer details: A to Z
                    </label>
                </div>
            </li>
            <li class=""mx-3 my-2"">
                <div class=""form-check"">
                    <input class=""form-check-input"" value=""4"" onclick=""sortingDropdown(2,'desc',4)"" type=""radio"" name=""serviceHistoryRadio"" id=""customerZHistory"">
                    <label class=""form-check-label"" for=""customerZHistory"">
                        Customer details: Z to A
                    </label>
                </div>
            </li>
        </ul>
    </div>
</div>

<table id=""serviceHistoryTable"" class=""table w-100"">
    <thead>
        <tr class=""d-md-table-row d-none table-header"">
            <th><span>Service Id</span><span class=""sort-icon""></span></th>
            <th><span>Service Date</span><span class=""sort-i");
            WriteLiteral("con\"></span></th>\r\n            <th><span>Customer Details</span><span class=\"sort-icon\"></span></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 73 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
         foreach (ServiceRequest sr in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td class=\"cursorPointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3779, "\"", 3836, 3);
            WriteAttributeValue("", 3789, "openServiceDetailsModal(", 3789, 24, true);
#nullable restore
#line 76 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 3813, sr.ServiceRequestId, 3813, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3833, ",3)", 3833, 3, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 76 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                               Write(sr.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <span hidden>");
#nullable restore
#line 78 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                            Write(sr.ServiceStartDate.ToString("yyyy-MM-dd").Replace('-', '/'));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    <div class=\"cursorPointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4036, "\"", 4093, 3);
            WriteAttributeValue("", 4046, "openServiceDetailsModal(", 4046, 24, true);
#nullable restore
#line 79 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 4070, sr.ServiceRequestId, 4070, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4090, ",3)", 4090, 3, true);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9ce123ebde92bbe82752e6419b7e753fee17595112843", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<span> ");
#nullable restore
#line 79 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                                                                                      Write(sr.ServiceStartDate.Date.ToString("dd-MM-yyyy").Replace('-', '/'));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n                    <div class=\"cursorPointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4272, "\"", 4329, 3);
            WriteAttributeValue("", 4282, "openServiceDetailsModal(", 4282, 24, true);
#nullable restore
#line 80 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 4306, sr.ServiceRequestId, 4306, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4326, ",3)", 4326, 3, true);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9ce123ebde92bbe82752e6419b7e753fee17595115042", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<span> ");
#nullable restore
#line 80 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                                                                                     Write(sr.ServiceStartDate.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 80 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                                                                                                                              Write(sr.ServiceStartDate.AddHours(sr.ServiceHours).ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n                </td>\r\n                <td>\r\n                    <div class=\"d-flex justify-content-start gap-2\">\r\n                        <div class=\"d-flex align-items-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9ce123ebde92bbe82752e6419b7e753fee17595117310", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div>\r\n                            <p class=\"mb-0\">");
#nullable restore
#line 88 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                       Write(sr.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 88 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                          Write(sr.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"mb-0\">");
#nullable restore
#line 89 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                       Write(sr.ServiceRequestAddresses.ElementAt(0).AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 89 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                             Write(sr.ServiceRequestAddresses.ElementAt(0).AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <p class=\"mb-0\">");
#nullable restore
#line 90 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                       Write(sr.ServiceRequestAddresses.ElementAt(0).PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 90 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                           Write(sr.ServiceRequestAddresses.ElementAt(0).City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 95 "C:\Users\jasan\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<script>
    $(""#serviceHistoryTable"").DataTable({
        searching: false,
        dom: `<'d-block't>
              <'d-flex justify-content-between align-items-center flex-wrap'
                <'mt-3'li>
                <'mt-3'p>
              >`,
        pagingType: ""full_numbers"",
        language: {
            info: "" Total Records : _TOTAL_"",
            infoPostFix: "" "",
            paginate: {
                previous: '<i class=""bi bi-chevron-left""></i>',
                next: '<i class=""bi bi-chevron-right""></i>',
                first: '<i class=""bi bi-skip-start-fill""></i>',
                last: '<i class=""bi bi-skip-end-fill""></i>',
            },
        },
        ""pageLength"": 10,
        ""lengthMenu"": [[5, 10, 20, 50, 100], [5, 10, 20, 50, 100]],
        ""order"": [],
    });

    var table = $('#serviceHistoryTable').DataTable();
    function sortingDropdown(column, orderby) {
        table.order([[column, orderby]]).draw();
    }
</sc");
            WriteLiteral("ript>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ServiceRequest>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
