#pragma checksum "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Shared\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dac1d3ca154aab9eddbc3454e0b22ea218d9061b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AccessDenied), @"mvc.1.0.view", @"/Views/Shared/AccessDenied.cshtml")]
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
#line 1 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\_ViewImports.cshtml"
using Stackoverflow.Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\_ViewImports.cshtml"
using Stackoverflow.Website.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\_ViewImports.cshtml"
using Stackoverflow.Website.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\_ViewImports.cshtml"
using Stackoverflow.Website.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\_ViewImports.cshtml"
using Stackoverflow.Website.BusinessModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dac1d3ca154aab9eddbc3454e0b22ea218d9061b", @"/Views/Shared/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"260230869019eb16ed2f4e620ec162c8dc447b6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Shared\AccessDenied.cshtml"
  
    ViewData["Title"] = "Access Denied";
    var message = ViewData["Message"]?.ToString() ?? "You don't have access to this resource.";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Access Denied</h1>\r\n<h2 class=\"text-danger\">");
#nullable restore
#line 7 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Shared\AccessDenied.cshtml"
                   Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>");
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
