#pragma checksum "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b1203c6efe56ed4c942e994f786e4899e9fdb3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_ServiceDetails), @"mvc.1.0.view", @"/Views/ServiceProvider/ServiceDetails.cshtml")]
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
#line 1 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b1203c6efe56ed4c942e994f786e4899e9fdb3d", @"/Views/ServiceProvider/ServiceDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42bc9d6e9e8a14112369f9b64e80a3af6cdab224", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ServiceProvider_ServiceDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceRequest>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/right_price.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/redcross.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
  
    ViewData["Title"] = "Service Details";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"d-flex color-4f-grey w-100\">\r\n    <div class=\"serviceDetailsLeft w-100\">\r\n        <div class=\"t-22 fw-bold\">\r\n            ");
#nullable restore
#line 9 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
       Write(Model.ServiceStartDate.ToString("dd-MM-yyyy").Replace("-", "/"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                        Write(Model.ServiceStartDate.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("-");
#nullable restore
#line 9 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                                                                  Write(Model.ServiceStartDate.AddHours(Model.ServiceHours).ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div><span class=\"fw-bold\">Duration: </span><span>");
#nullable restore
#line 11 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                     Write(Model.ServiceHours);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Hrs</span></div>\r\n        <div class=\"dropdown-divider\"></div>\r\n        <div><span class=\"fw-bold\">Service Id: </span><span>");
#nullable restore
#line 13 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                       Write(Model.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>.</div>\r\n        <div>\r\n            <span class=\"fw-bold\">Extras: </span>\r\n");
#nullable restore
#line 16 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
             foreach (var item in Model.ServiceRequestExtras.Select((value, i) => (value, i)))
            {
                if (item.value.ServiceExtraId == 1)
                {
                    if (item.i == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Inside cabinets, </span>\r\n");
#nullable restore
#line 23 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                    }
                    if (item.i == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Inside fridge, </span>\r\n");
#nullable restore
#line 27 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                    }
                    if (item.i == 2)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Inside oven, </span>\r\n");
#nullable restore
#line 31 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                    }
                    if (item.i == 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Laundry wash & dry, </span>\r\n");
#nullable restore
#line 35 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                    }
                    if (item.i == 4)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Interior windows, </span>\r\n");
#nullable restore
#line 39 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                    }
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"d-flex align-items-center gap-2\">\r\n            <span class=\"fw-bold\">Total Payment: </span><span class=\"color-secondary fw-bold t-24 text-center\">");
#nullable restore
#line 44 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                                                          Write(Model.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &euro;</span>\r\n        </div>\r\n        <div class=\"dropdown-divider\"></div>\r\n        <div><span class=\"fw-bold\">Customer Name: </span><span>");
#nullable restore
#line 47 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                          Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 47 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                                Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n");
#nullable restore
#line 48 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
         foreach (var serviceRequestAddress in Model.ServiceRequestAddresses)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div><span class=\"fw-bold\">Service Address: </span><span>");
#nullable restore
#line 50 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                Write(serviceRequestAddress.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                                                    Write(serviceRequestAddress.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                                                                                        Write(serviceRequestAddress.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 50 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                                                                                                                                                          Write(serviceRequestAddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n");
#nullable restore
#line 51 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"dropdown-divider\"></div>        <div class=\"fw-bold\">Comments</div>\r\n        <div class=\"t-14 color-64-grey mx-3 mb-3\">");
#nullable restore
#line 53 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
                                             Write(Model.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 54 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
         if (Model.HasPets)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex align-items-center gap-2\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b1203c6efe56ed4c942e994f786e4899e9fdb3d13576", async() => {
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
            WriteLiteral(" <span>I have pets at home</span></div>\r\n");
#nullable restore
#line 57 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex align-items-center gap-2\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b1203c6efe56ed4c942e994f786e4899e9fdb3d15058", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <span>I don\'t have pets at home</span></div>\r\n");
#nullable restore
#line 61 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 63 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
         if (ViewBag.requestOrigin == 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex justify-content-center justify-content-md-start flex-wrap gap-3\">\r\n                <div");
            BeginWriteAttribute("onclick", " onclick=\"", 3114, "\"", 3168, 3);
            WriteAttributeValue("", 3124, "openRescheduleModal(", 3124, 20, true);
#nullable restore
#line 66 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
WriteAttributeValue("", 3144, Model.ServiceRequestId, 3144, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3167, ")", 3167, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"accept-button-green py-2 ps-0 ps-2 px-md-3 d-flex align-items-center gap-1\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b1203c6efe56ed4c942e994f786e4899e9fdb3d17578", async() => {
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
            WriteLiteral("<span>Accept</span></div>\r\n            </div>\r\n");
#nullable restore
#line 68 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
         if (ViewBag.requestOrigin == 2)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex justify-content-center justify-content-md-start flex-wrap gap-2\">\r\n                <div");
            BeginWriteAttribute("onclick", " onclick=\"", 3527, "\"", 3581, 3);
            WriteAttributeValue("", 3537, "openRescheduleModal(", 3537, 20, true);
#nullable restore
#line 72 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
WriteAttributeValue("", 3557, Model.ServiceRequestId, 3557, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3580, ")", 3580, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"reschedule-button py-2 px-3\">Complete</div>\r\n                <div");
            BeginWriteAttribute("onclick", " onclick=\"", 3655, "\"", 3709, 3);
            WriteAttributeValue("", 3665, "openRescheduleModal(", 3665, 20, true);
#nullable restore
#line 73 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
WriteAttributeValue("", 3685, Model.ServiceRequestId, 3685, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3708, ")", 3708, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"cancel-button py-2 px-3\">Cancel</div>\r\n            </div>\r\n");
#nullable restore
#line 75 "C:\Users\Kuldip Jasani\Desktop\Tatva\tatvasoft-training\Helperland\Helperland\Views\ServiceProvider\ServiceDetails.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"serviceDetailsRight\">\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceRequest> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
