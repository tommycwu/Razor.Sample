#pragma checksum "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e02fd592595524b66db7978cdc0f00bc05bd7d6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Razor.Sample.Pages.Pages_OTP), @"mvc.1.0.razor-page", @"/Pages/OTP.cshtml")]
namespace Razor.Sample.Pages
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
#line 1 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\_ViewImports.cshtml"
using Razor.Sample;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e02fd592595524b66db7978cdc0f00bc05bd7d6b", @"/Pages/OTP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82e96a3eca4cb8ee4468b4462365bccb602a3fb5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_OTP : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
  
    ViewData["Title"] = "OTP";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
 if (ViewData["otp"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>OTP</h3>\r\n");
#nullable restore
#line 10 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Tokens</h3>\r\n");
#nullable restore
#line 14 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"border container\" style=\"padding:30px; width:880px\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e02fd592595524b66db7978cdc0f00bc05bd7d6b4147", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
         if (ViewData["otp"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <div id=""otp1"" class=""form-group row"">
                <div class=""col-3"">
                    <label for=""otp"">Enter Code:</label>
                </div>
                <div class=""col-6"">
                    <input type=""text"" name=""otp"" />
                </div>
            </div>
            <div id=""otp2"" class=""form-group row"">
                <div class=""col-3 offset-3"">
                    <input type=""submit"" value=""verify"" class=""btn btn-primary form-control"" />
                </div>
            </div>
");
#nullable restore
#line 33 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
         if (ViewData["id_Token"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <font size=\"2\">id_Token</font>\r\n            <p><font size=\"1\"><textarea rows=\"4\" style=\"width:800px; word-wrap:break-word;\">");
#nullable restore
#line 38 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
                                                                                       Write(ViewData["id_Token"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></font></p>\r\n            <p><font size=\"1\"><textarea rows=\"10\" style=\"width:800px; word-wrap:break-word;\">");
#nullable restore
#line 39 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
                                                                                        Write(ViewData["idTokenJson"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></font></p>\r\n");
#nullable restore
#line 40 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
         if (ViewData["access_Token"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <font size=\"2\">access_Token</font>\r\n            <p><font size=\"1\"><textarea rows=\"4\" style=\"width:800px; word-wrap:break-word;\">");
#nullable restore
#line 44 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
                                                                                       Write(ViewData["access_Token"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></font></p>\r\n            <p><font size=\"1\"><textarea rows=\"10\" style=\"width:800px; word-wrap:break-word;\"> ");
#nullable restore
#line 45 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
                                                                                         Write(ViewData["accessTokenJson"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</textarea></font></p>\r\n");
#nullable restore
#line 46 "C:\Users\tommy.wu\source\repos\Razor.Sample\Pages\OTP.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Razor.Sample.Pages.OTPModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Razor.Sample.Pages.OTPModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Razor.Sample.Pages.OTPModel>)PageContext?.ViewData;
        public Razor.Sample.Pages.OTPModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
