#pragma checksum "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "530094b740e1b8c3361237afb72026f726942587"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Questions_Index), @"mvc.1.0.view", @"/Views/Questions/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"530094b740e1b8c3361237afb72026f726942587", @"/Views/Questions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"260230869019eb16ed2f4e620ec162c8dc447b6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Questions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AllQuestionsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/questions.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Questions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary float-right fz-1-5rem"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/default.jpeg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("35"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("35"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
  
    ViewData["Title"] = "Questions";
    ViewData["Page"] = Pages.Questions;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "530094b740e1b8c3361237afb72026f7269425877684", async() => {
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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"row\">\r\n    <h2 class=\"col-md-4\">All Questions</h2>\r\n    <div class=\"col-md-8\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "530094b740e1b8c3361237afb72026f7269425879032", async() => {
                WriteLiteral("Ask Question");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<br />\r\n<br />\r\n<h3>");
#nullable restore
#line 19 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
Write(Model.Questions.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Questions</h3>\r\n<br />\r\n<hr />\r\n");
#nullable restore
#line 22 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
 if (!Model.Questions.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>No Questions Available</h3>\r\n");
#nullable restore
#line 25 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"questions\">\r\n");
#nullable restore
#line 29 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
         foreach (var question in Model.Questions)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"question\">\r\n                <div class=\"counts\">\r\n                    <div class=\"count\">\r\n                        <span class=\"count-value\">");
#nullable restore
#line 34 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                                             Write(question.Votes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"count-title\">Votes</span>\r\n                    </div>\r\n                    <div");
            BeginWriteAttribute("class", " class=\"", 988, "\"", 1104, 3);
            WriteAttributeValue("", 996, "count", 996, 5, true);
#nullable restore
#line 37 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
WriteAttributeValue(" ", 1001, question.Answers > 0 ? "has-answer" : "", 1002, 43, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
WriteAttributeValue(" ", 1045, question.HasAcceptedAnswer ? "has-accepted-answer" : "", 1046, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span class=\"count-value\">");
#nullable restore
#line 38 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                                             Write(question.Answers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"count-title\">Answers</span>\r\n                    </div>\r\n                </div>\r\n                <div class=\"question-detail\">\r\n                    <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "530094b740e1b8c3361237afb72026f72694258713477", async() => {
#nullable restore
#line 43 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                                                                                                                        Write(question.Title);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-questionId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                                                                                     WriteLiteral(question.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["questionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-questionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["questionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 44 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                     if (question.Description.Length > 200)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>");
#nullable restore
#line 46 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                      Write(question.Description.Substring(0, 200));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ...</p>\r\n");
#nullable restore
#line 47 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>");
#nullable restore
#line 50 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                      Write(question.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 51 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                     if (question.Tags.Any())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"tags\">\r\n");
#nullable restore
#line 55 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                             foreach (var tag in question.Tags.SplitByComma())
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"tag\">");
#nullable restore
#line 57 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                                             Write(tag);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 58 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 60 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"float-right\">asked ");
#nullable restore
#line 61 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                                               Write(question.AskedFromUtc.ToLocalTime().ToFormatedDatetimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" .</span><br />\r\n                    <div class=\"float-right\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "530094b740e1b8c3361237afb72026f72694258719584", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a href=\"#\">");
#nullable restore
#line 64 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
                               Write(question.AskerDisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 68 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 70 "D:\Projects\University\SW2\Stackoverflow\Stackoverflow.Website\Views\Questions\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AllQuestionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
