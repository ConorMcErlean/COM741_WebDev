#pragma checksum "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\Shared\_RenderAlert.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d5f55657211a4ea620d48baa24a656a90d6b9c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__RenderAlert), @"mvc.1.0.view", @"/Views/Shared/_RenderAlert.cshtml")]
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
#line 1 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\_ViewImports.cshtml"
using SMS.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\_ViewImports.cshtml"
using SMS.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\_ViewImports.cshtml"
using SMS.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d5f55657211a4ea620d48baa24a656a90d6b9c0", @"/Views/Shared/_RenderAlert.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c24b92113edd38f3b0c228b9decc2901c82db85", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__RenderAlert : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\Shared\_RenderAlert.cshtml"
  
    var message = TempData["Alert.Message"] ?? null;
    var type    = TempData["Alert.Type"]    ?? null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\Shared\_RenderAlert.cshtml"
 if (message != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 149, "\"", 174, 3);
            WriteAttributeValue("", 157, "alert", 157, 5, true);
            WriteAttributeValue(" ", 162, "alert-", 163, 7, true);
#nullable restore
#line 7 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\Shared\_RenderAlert.cshtml"
WriteAttributeValue("", 169, type, 169, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n        ");
#nullable restore
#line 8 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\Shared\_RenderAlert.cshtml"
   Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 10 "D:\Work\WebDev\COM741_WebDev\Practical11\SMS.Web\Views\Shared\_RenderAlert.cshtml"
}

#line default
#line hidden
#nullable disable
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
