#pragma checksum "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bafb2297027263f79cf2c9ba1952a48b47aedf5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vehicle_Index), @"mvc.1.0.view", @"/Views/Vehicle/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bafb2297027263f79cf2c9ba1952a48b47aedf5", @"/Views/Vehicle/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8296bf2ec5498a351980ec33e0259d7efc7efbd", @"/Views/_ViewImports.cshtml")]
    public class Views_Vehicle_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<Vehicle>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-id", "v.Id", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<h3>All Vehicles</h3>

<table class=""table table-striped"">
    <thead>
        <!-- Heading of table, Adjust based on how much is to be shown -->
        <tr>
            <th>Id</th>
            <th>Make</th>
            <th>Model</th>
            <th>Colour</th>
            <th>Fuel Type</th>
            <th>Image</th>
            <th>Options</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 20 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
         foreach (var v in Model)
        {
            // Row Details

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n               <td>");
#nullable restore
#line 24 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
              Write(v.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 25 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
              Write(v.Make);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 26 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
              Write(v.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 27 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
              Write(v.Colour);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>");
#nullable restore
#line 28 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
              Write(v.FuelType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td>\r\n                   <!-- Image -->\r\n                   <img");
            BeginWriteAttribute("src", " src=\"", 774, "\"", 788, 1);
#nullable restore
#line 31 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
WriteAttributeValue("", 780, v.Photo, 780, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 807, "\"", 851, 6);
            WriteAttributeValue("", 813, "Image", 813, 5, true);
            WriteAttributeValue(" ", 818, "of", 819, 3, true);
#nullable restore
#line 31 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
WriteAttributeValue(" ", 821, v.Make, 822, 7, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
WriteAttributeValue(" ", 829, v.Model, 830, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 838, "in", 839, 3, true);
#nullable restore
#line 31 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
WriteAttributeValue(" ", 841, v.Colour, 842, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n               </td>\r\n               <td>\r\n                   <!-- Function Buttons --> \r\n                   ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5bafb2297027263f79cf2c9ba1952a48b47aedf58656", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
                                                                                  WriteLiteral(v.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n                   ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5bafb2297027263f79cf2c9ba1952a48b47aedf511034", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n               </td>\r\n            </tr>\r\n");
#nullable restore
#line 41 "D:\Work\WebDev\COM741_WebDev\Assignment\VMS.Web\Views\Vehicle\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<Vehicle>> Html { get; private set; }
    }
}
#pragma warning restore 1591
