#pragma checksum "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d787c4ca5b4531248012463306494b4b6a6754f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_Details), @"mvc.1.0.view", @"/Views/Vehicle/Details.cshtml")]
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
#line 1 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\_ViewImports.cshtml"
using VMS.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\_ViewImports.cshtml"
using VMS.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\_ViewImports.cshtml"
using VMS.Web.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d787c4ca5b4531248012463306494b4b6a6754f", @"/Views/Vehicle/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8296bf2ec5498a351980ec33e0259d7efc7efbd", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Services", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Vehicle\r\n\r\n<h3>Vehicle Details</h3>\r\n<div class=\"row\">\r\n    <div class=\"col-3\">\r\n                <h5>Make:</h5><h3>");
#nullable restore
#line 6 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
                             Write(Model.Make);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"col-3\">\r\n                <h5>Model:</h5><h3>");
#nullable restore
#line 9 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
                              Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"col-3\">\r\n                <h5>Fuel Type:</h5><h3>");
#nullable restore
#line 12 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
                                  Write(Model.FuelType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <div class=\"col-3\">\r\n          <!-- Blank Grid Space -->      \r\n    </div>    \r\n</div>\r\n<div class=\"row\">\r\n    <div class=\"col-8\">\r\n        <!-- Image -->\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 513, "\"", 531, 1);
#nullable restore
#line 21 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
WriteAttributeValue("", 519, Model.Photo, 519, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 550, "\"", 606, 6);
            WriteAttributeValue("", 556, "Image", 556, 5, true);
            WriteAttributeValue(" ", 561, "of", 562, 3, true);
#nullable restore
#line 21 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
WriteAttributeValue(" ", 564, Model.Make, 565, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
WriteAttributeValue(" ", 576, Model.Model, 577, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 589, "in", 590, 3, true);
#nullable restore
#line 21 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
WriteAttributeValue(" ", 592, Model.Colour, 593, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    </div>\r\n\r\n    <div class=\"col-4\">\r\n        <dl>\r\n            <dt>Colour</dt>\r\n            <dd>");
#nullable restore
#line 27 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.Colour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Registration Date</dt>\r\n            <dd>");
#nullable restore
#line 30 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.RegDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Registration Number</dt>\r\n            <dd>");
#nullable restore
#line 33 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.RegNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Age</dt>\r\n            <dd>");
#nullable restore
#line 36 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Transmission Type</dt>\r\n            <dd>");
#nullable restore
#line 39 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.TransmissionType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Co2 Rating</dt>\r\n            <dd>");
#nullable restore
#line 42 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.CO2Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Body Type</dt>\r\n            <dd>");
#nullable restore
#line 45 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.BodyType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n            <dt>Number of Doors</dt>\r\n            <dd>");
#nullable restore
#line 48 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Details.cshtml"
           Write(Model.Doors);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        </dl>\r\n    </div>\r\n    \r\n</div>\r\n\r\n<!-- Partial To Render Service Record -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8d787c4ca5b4531248012463306494b4b6a6754f8820", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591